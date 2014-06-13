using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Northwind.WCFContracts.DataContract;
using Northwind.WCFContracts.ServiceContracts;
using Northwind.WCFContracts.FaultContracts;

using Northwind.BLL;
using Northwind.DomainModels;

namespace Northwind.WCFDataService
{
    /// <summary>
    /// <para>
    /// Northwind Data Service
    /// </para>
    /// <para>
    /// Inherit the INorthwindServiceContract service contract defined in the Northwind.WCFContracts project.
    /// </para>
    /// </summary>
    public class NorthwindDataService : INorthwindServiceContract
    {
        /// <summary>
        /// Instanciate NorthwindBusinessLogic object for use throughout the DataService.
        /// </summary>
        private NorthwindBusinessLogic bll = new NorthwindBusinessLogic();

        /// <summary>
        /// todo - add comments
        /// </summary>
        SantizedException SntzEx = new SantizedException();

        /// <summary>
        /// <para>
        /// Current Date Time of the server hosting the service.  This will be formatted like 6/15/2009 13:45:30.617. 
        /// </para>
        /// </summary>
        /// <returns>If non-zero, the tenths of a second in a date and time value.</returns>
        public string getTime()
        {

            try
            {
                return DateTime.Now.ToString("F");
            }
            catch (Exception ex)
            {
                SntzEx.RaiseFaultException(ex);
                return null;
            }        
        
        }

        /// <summary>
        /// <para>
        /// Gets the identity of the current principal. 
        /// </para>
        /// </summary>
        /// <returns>Name of Identity</returns>
        public string whoAmI()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        /// <summary>
        /// Get Employee information for ID provided.
        /// </summary>
        /// <param name="employeeid">Employee ID</param>
        /// <returns>Employee Data Contract object; otherwise, Fault.</returns>
        public Employee getEmployeeById(int employeeid)
        {

            //Employee[] employees = SelectEmployees();
            //Employee emp = (from e in employees
            //               where e.EmployeeId == employeeid
            //               select e).Single();
            //return emp;

            Employee emp = Mapper.Map(bll.SelectEmployeesById(employeeid));
            return emp;

        }

        /// <summary>
        /// Get a collection of Employee Data Contract objects.
        /// </summary>
        /// <returns>Array of Employee Data Contract objects; otherwise, Fault.</returns>
        public Employee[] getEmployees()
        {
            List<Employee> objs = new List<Employee>();
            objs.Add(new Employee { EmployeeId = 1, FirstName = "Me", HomePhone = "111111", LastName = "last", Title = "me" });
            objs.Add(new Employee { EmployeeId = 2, FirstName = "Me2", HomePhone = "111111", LastName = "last", Title = "me" });
            objs.Add(new Employee { EmployeeId = 3, FirstName = "Me3", HomePhone = "111111", LastName = "last", Title = "me" });
            return objs.ToArray(); 

            //try
            //{
            //    throw new ApplicationException("no soup for you");

            //    // intercept the data from the CLL and convert it to DataContract Type.
            //    Employee[] employees = Mapper.Map(bll.SelectEmployees());

            //    System.Threading.Thread.Sleep(10000);

            //    // return the array to the consumer
            //    return employees;
            //}
            //catch (Exception ex)
            //{
            //    CustomException CustEx = new CustomException { ErrorTitle = "Error Funtion: SelectProducts", ExceptionMessage = ex.Message.ToString() };
            //    throw new FaultException<CustomException>(CustEx,  "Fault Reason - Paul Said Too!");
            //}

        }

        /// <summary>
        /// getProducts
        /// </summary>
        /// <returns>Array of Product Data Contract objects; otherwise, Fault.</returns>
        public Product[] getProducts()
        {
            //List<Product> objs = new List<Product>();
            //objs.Add(new Product { ProductID=1, ProductName="name", UnitPrice= 12.12M });
            //objs.Add(new Product { ProductID = 1, ProductName = "name", UnitPrice = 12.13M });
            //objs.Add(new Product { ProductID = 1, ProductName = "name", UnitPrice = 12.14M });
            //return objs.ToArray(); 

            try
            {

                throw new ApplicationException("no soup for you");

                // intercept the data from the CLL and convert it to DataContract Type.
                Product[] products = Mapper.Map(bll.SelectProducts());

                // return the array to the consumer
                return products;
            }
            catch (Exception)
            {
                ProductFaultException ex = new ProductFaultException { ErrorTitle = "Error Funtion: SelectProducts" };
                throw new FaultException<ProductFaultException>(ex, "GoodBye!");
            }

        }

        /// <summary>
        ///  Get Product Information for ID provided
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <returns>Product Data Contract object; otherwise, Fault.</returns>
        public Product getProductForId(int productID)
        {
            //Product[] products = SelectProducts();
            //Product prd = (from p in products
            //               where p.ProductID == productID
            //                select p).Single();
            //return prd;

            // intercept the data from the CLL and convert it to DataContract Type.
            Product product = Mapper.Map(bll.SelectProductsById(productID));

            // return the array to the consumer
            return product;

        }

        /// <summary>
        /// getEmployeeTitles
        /// </summary>
        /// <returns>Array of strings; otherwise, Fault</returns>
        public string[] getEmployeeTitles()
        {
            return bll.SelectEmployeeTitles().ToArray();
        }

        /// <summary>
        /// getEmployeesForTitle
        /// </summary>
        /// <param name="title">title</param>
        /// <returns>Array of Employee Data Contract object; otherwise, Fault.</returns>
        public Employee[] getEmployeesForTitle(string title)
        {
            // intercept the data from the BLL and convert it to DataContract Type.
            Employee[] employees = Mapper.Map(bll.SelectEmployeesByTitle(title));

            // return the array to the consumer
            return employees;
        }

        /// <summary>
        /// Create a new Employee record.
        /// </summary>
        /// <param name="employee">Employee Data Contract</param>
        /// <returns>int; otherwise, Fault</returns>
        public int postEmployee(Employee employee)
        {
            return bll.InsertEmployee(Mapper.Map(employee));
        }

        /// <summary>
        /// getEmployeeForId
        /// </summary>
        /// <param name="employeeid">ID</param>
        /// <returns>Employee Data Contract object; otherwise, Fault.</returns>
        public Employee getEmployeeForId(int employeeid)
        {
            throw new NotImplementedException();
        }


    }
}
