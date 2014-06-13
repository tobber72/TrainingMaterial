using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.WPFConsumer.NorthwindServiceClasses;
using Northwind.WPFConsumer.ViewModels;
using Northwind.WPFConsumer.ServiceGateways;

namespace Northwind.WPFConsumer.ServiceGateways
{
    /// <summary>
    /// The Data Gateway will contain methods that 
    /// will interact with the WCF service
    /// and guarnatee that all proxy objects will 
    /// close and proper data is returned to the 
    /// views for binding.
    /// </summary>
    public static class DataGateway
    {

        public static EmployeeViewModel[] SelectEmployees()
        {

            using (NorthwindServiceContractClient proxy = new NorthwindServiceContractClient("netTCP_EndPoint"))
            {
                EmployeeViewModel[] employees = Mapper.Map(proxy.SelectEmployees().ToList());
                return employees;
            }
                    
        }

        public static string[] SelectEmployeeTitles()
        {

            using (NorthwindServiceContractClient proxy = new NorthwindServiceContractClient("netTCP_EndPoint"))
            {
                return proxy.SelectEmployeeTitles();
            }

        }

        public static EmployeeViewModel[] SelectEmployeesByTitle(string title)
        {

            using (NorthwindServiceContractClient proxy = new NorthwindServiceContractClient("netTCP_EndPoint"))
            {

                EmployeeViewModel[] employees = Mapper.Map(proxy.SelectEmployeesByTitle(title).ToList());
                return employees;
            }

        }

        public static int InsertEmployee(EmployeeViewModel emp)
        {
            using (NorthwindServiceContractClient proxy = new NorthwindServiceContractClient("netTCP_EndPoint"))
            {
                return proxy.InsertEmployee(Mapper.Map(emp));
            }        
        }

    }
}
