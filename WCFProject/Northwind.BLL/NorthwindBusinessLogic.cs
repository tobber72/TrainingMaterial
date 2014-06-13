using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Northwind.DAL;
using Northwind.DomainModels;

namespace Northwind.BLL
{
    /// <summary>
    /// The northwind business logic class contains methods 
    /// that will call the methods of the dal and apply business 
    /// rules to the data if needed.
    /// </summary>
    public class NorthwindBusinessLogic
    {

        #region  Select Methods

        /// <summary>
        /// Create a DAL Object
        /// </summary>
        private NorthwindDataAccess DAL = new NorthwindDataAccess();

        /// <summary>
        /// Get Employees
        /// </summary>
        /// <returns>List of EmployeeDomainModel objects; otherwise, Exception.</returns>
        public List<EmployeeDomainModel> SelectEmployees()
        {

            // intercept the data from the DAL
            List<EmployeeDomainModel> employees = DAL.SelectEmployees();
            employees = employees.ConvertAll(x => HideHomePhone(x));

            //// apply a business rule.
            //foreach (EmployeeDomainModel employee in employees)
            //{
            //    if (employee.Title.Contains("Manager"))
            //    {
            //        employee.HomePhone = "Not Available";
            //    }
            //}

            return employees;
        }

        /// <summary>
        /// Get Employees for Id provided.
        /// </summary>
        /// <param name="employeeid">employeeid</param>
        /// <returns>EmployeeDomainModel object; otherwise, Exception.</returns>
        public EmployeeDomainModel SelectEmployeesById(int employeeid)
        {
            // intercept the data from the DAL
            EmployeeDomainModel employee = HideHomePhone(DAL.SelectEmployeesById(employeeid));

            return employee;
        }

        /// <summary>
        /// Hide Home Phone Number Business Rule
        /// </summary>
        /// <param name="obj">EmployeeDomainModel object</param>
        /// <returns>EmployeeDomainModel object; otherwise, Exception.</returns>
        private EmployeeDomainModel HideHomePhone(EmployeeDomainModel obj)
        {
            // apply a business rule.
            if (obj.Title.Contains("Manager"))
            {
                obj.HomePhone = "Not Available";
            }
            return obj;
        }

        /// <summary>
        /// Get Products:
        /// </summary>
        /// <returns>List of ProductDomainModel objects; otherwise, Exception.</returns>
        public List<ProductDomainModel> SelectProducts()
        {

            // intercept the data from the DAL
            //List<ProductDomainModel> products = DAL.SelectProducts();
            //return products;

            return DAL.SelectProducts();

        }

        /// <summary>
        /// Get Products for Id provided
        /// </summary>
        /// <param name="prorductID">Product ID </param>
        /// <returns>ProductDomainModel objects; otherwise, Exception.</returns>
        public ProductDomainModel SelectProductsById(int prorductID)
        {
            // intercept the data from the DAL
            return DAL.SelectProductById(prorductID);
        }

        /// <summary>
        /// Get Employee Titles 
        /// </summary>
        /// <returns>List of string; otherwise, Exception.</returns>
        public List<string> SelectEmployeeTitles()
        {
            return DAL.SelectEmployeeTitles();
        }

        /// <summary>
        /// Get Employees by Title
        /// </summary>
        /// <param name="title">Title</param>
        /// <returns>ProductDomainModel objects; otherwise, Exception.</returns>
        public List<EmployeeDomainModel> SelectEmployeesByTitle(string title)
        {
            // intercept the data from the DAL
            List<EmployeeDomainModel> employees = DAL.SelectEmployeesByTitle(title);
            employees = employees.ConvertAll(x => HideHomePhone(x));
            return employees;
        }

        #endregion

        #region Insert Methods

        public int InsertEmployee(EmployeeDomainModel employee)
        {
            return DAL.InsertEmployee(employee);        
        }

        #endregion

    }
}
