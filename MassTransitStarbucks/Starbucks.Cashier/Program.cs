// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.

namespace Starbucks.Cashier
{
    using System;
    using System.Diagnostics;
    using Magnum;
    using Magnum.StateMachine;
    using MassTransit.Log4NetIntegration.Logging;

    using Topshelf;
    using Microsoft.Practices.Unity;
    using MassTransit.Saga;
    using MassTransit;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log4NetLogger.Use("cashier.log4net.xml");

            var container = new UnityContainer();

            // register types directly
            container.RegisterType<CashierService>(new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(ISagaRepository<>), typeof(InMemorySagaRepository<>), new ContainerControlledLifetimeManager());

            // Register the ServiceBus.
            container.RegisterInstance<IServiceBus>(ServiceBusFactory.New(sbc =>
            {
                // Configure exchanges.
                sbc.ReceiveFrom("msmq://localhost/starbucks_cashier");
                sbc.UseMsmq();
                sbc.UseMulticastSubscriptionClient();

                sbc.SetConcurrentConsumerLimit(1); //a cashier cannot multi-task
                sbc.UseControlBus();
                sbc.EnableRemoteIntrospection();

                sbc.Subscribe(subs => { subs.LoadFrom(container); });
            }));


            HostFactory.Run(c =>
            {
                c.SetServiceName("StarbucksCashier");
                c.SetDisplayName("Starbucks Cashier");
                c.SetDescription("a Mass Transit sample service for handling orders of coffee..");

                c.DependsOnMsmq();
                c.RunAsLocalService();

                DisplayStateMachine();

                c.Service<CashierService>(s =>
                {
                    s.ConstructUsing(builder => container.Resolve<CashierService>());
                    s.WhenStarted(o => o.Start());
                    s.WhenStopped(o =>
                    {
                        o.Stop();
                        container.Dispose();
                    });
                });
            });
        }

        static void DisplayStateMachine()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            StateMachineInspector.Trace(new CashierSaga(CombGuid.Generate()));
        }
    }
}