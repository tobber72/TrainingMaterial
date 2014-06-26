using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace Core.Common.ServiceModel
{
    public abstract class InterceptorClientBase<T> : ClientBase<T> where T : class
    {
        public InterceptorClientBase()
        {
            Endpoint.Behaviors.Add(new ClientInterceptor(this));
        }

        protected virtual void PreInvoke(ref Message request) { }

        protected virtual void PostInvoke(ref Message reply) { }

        class ClientInterceptor : IEndpointBehavior, IClientMessageInspector
        {
            InterceptorClientBase<T> _Proxy { get; set; }

            internal ClientInterceptor(InterceptorClientBase<T> proxy)
            {
                _Proxy = proxy;
            }

            object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                _Proxy.PreInvoke(ref request);
                return null;
            }
            void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
            {
                _Proxy.PostInvoke(ref reply);
            }

            void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.MessageInspectors.Add(this);
            }

            void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
            void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }
            void IEndpointBehavior.Validate(ServiceEndpoint endpoint) { }
        }
    }
}
