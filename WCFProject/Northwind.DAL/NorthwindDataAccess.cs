using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.DomainModels;

namespace Northwind.DAL
{
    /// <summary>
    /// The NorthwindDataAccess class contains methos that 
    /// will us one or 2 data access technologies
    /// ADO.Net or the entity framework.
    /// </summary>
    public class NorthwindDataAccess
    {

        #region Select Methods

        /// <summary>
        /// Get a collection of Employees information in the Northwind Database.
        /// </summary>
        /// <returns>List of EmployeeDomainModel objects; otherwise, Exception.</returns>
        public List<EmployeeDomainModel> SelectEmployees()
        { 
            // write implementation code to access northwind database.
            // Create a context object wrapped in a using statement.
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {

                // ------------------------------------------------------------
                // USE A TABLE TO GET RESULTS
                //return (from n in northwindConnection.Employees
                //        select new EmployeeDomainModel
                //        {
                //            EmployeeId = n.EmployeeID,
                //            FirstName = n.FirstName,
                //            HomePhone = n.HomePhone,
                //            LastName = n.LastName,
                //            Title = n.Title
                //        }).ToList();

                // ------------------------------------------------------------
                // USE A SP TO GET RESULTS.
                return (from proc in northwindConnection.SelectEmployees()
                        select new EmployeeDomainModel
                        {
                            EmployeeId = proc.EmployeeID,
                            FirstName = proc.FirstName,
                            HomePhone = proc.HomePhone,
                            LastName = proc.LastName,
                            Title = proc.Title
                        }).ToList();

            
            }

        }

        /// <summary>
        /// Get Employees for Id provided
        /// </summary>
        /// <param name="employeeid">Employee ID</param>
        /// <returns>EmployeeDomainModel object; otherwise, Exception.</returns>
        public EmployeeDomainModel SelectEmployeesById(int employeeid)
        {
            // write implementation code to access northwind database.
            // Create a context object wrapped in a using statement.
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {

                return (from n in northwindConnection.Employees
                        where n.EmployeeID == employeeid
                        select new EmployeeDomainModel
                        {
                            EmployeeId = n.EmployeeID,
                            FirstName = n.FirstName,
                            HomePhone = n.HomePhone,
                            LastName = n.LastName,
                            Title = n.Title
                        }).Single();
            }

        }

        /// <summary>
        /// Get a collection of Product information.
        /// </summary>
        /// <returns>List of ProductDomainModel objects; otherwise, Exception.</returns>
        public List<ProductDomainModel> SelectProducts()
        {

            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {
                return (from n in northwindConnection.Products
                        select new ProductDomainModel
                        {
                            ProductID = n.ProductID,
                            ProductName = n.ProductName,
                            UnitPrice = (decimal)n.UnitPrice
                        }).ToList();
            
            }

        }

        /// <summary>
        /// Get Products for ID provided.
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <returns>ProductDomainModel object; otherwise, Exception.</returns>
        public ProductDomainModel SelectProductById(int productID)
        {
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {
                return (from n in northwindConnection.Products
                        where n.ProductID == productID
                        select new ProductDomainModel
                        {
                            ProductID = n.ProductID,
                            ProductName = n.ProductName,
                            UnitPrice = (decimal)n.UnitPrice
                        }).Single();

            }
        }

        /// <summary>
        /// Get Employee Titles
        /// </summary>
        /// <returns>List of string objects; otherwise, Exception.</returns>
        public List<string> SelectEmployeeTitles()
        {
            // write implementation code to access northwind database.
            // Create a context object wrapped in a using statement.
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {

                // ------------------------------------------------------------
                // USE A SP TO GET RESULTS.
                return (from table in northwindConnection.Employees
                        select table.Title).Distinct().ToList();

            }

        }

        /// <summary>
        /// Get collection of Employee Info for Title provided
        /// </summary>
        /// <param name="title">Title</param>
        /// <returns>List of EmployeeDomainModel objects; otherwise, Exception.</returns>
        public List<EmployeeDomainModel> SelectEmployeesByTitle(string title)
        {
            // write implementation code to access northwind database.
            // Create a context object wrapped in a using statement.
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {

                // ------------------------------------------------------------
                // USE A TABLE TO GET RESULTS.
                return (from table in northwindConnection.Employees
                        where table.Title == title
                        select new EmployeeDomainModel
                        {
                            EmployeeId = table.EmployeeID,
                            FirstName = table.FirstName,
                            HomePhone = table.HomePhone,
                            LastName = table.LastName,
                            Title = table.Title
                        }).ToList();

            }

        }


        #endregion


        #region Insert Methods

        /// <summary>
        /// Insert a new employee record into the Northwind database.
        /// </summary>
        /// <param name="employee">Employee object</param>
        /// <returns>int; otherwise, Exception.</returns>
        public int InsertEmployee(EmployeeDomainModel employee)
        {

            // Create a context object wrapped in a using statement.
            using (NorthwindEntities northwindConnection = new NorthwindEntities())
            {
                return northwindConnection.InsertEmployee(employee.LastName, employee.FirstName, employee.Title, employee.HomePhone);
            }
        
        }

        #endregion


    }

}
