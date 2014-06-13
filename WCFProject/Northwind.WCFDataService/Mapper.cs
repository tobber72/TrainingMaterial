using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Northwind.DomainModels;
using Northwind.WCFContracts.DataContract;
using Northwind.WCFContracts.FaultContracts;

namespace Northwind.WCFDataService
{
    /// <summary>
    /// The mapper class will convert domain models into 
    /// datacontracts and visa versa
    /// </summary>
    public static class Mapper
    {


        #region Convert From EmployeeDomainModel To Employee
        /// <summary>
        ///  Convert From EmployeeDomainModel To Employee
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Employee Map(EmployeeDomainModel obj)
        {
            return new Employee
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                HomePhone = obj.HomePhone,
                LastName = obj.LastName,
                Title = obj.Title
            };
        }

        /// <summary>
        ///  Convert From EmployeeDomainModel To Employee
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static Employee[] Map(List<EmployeeDomainModel> objs)
        {
            // AWESOME!
            return objs.ConvertAll(x => Map(x)).ToArray();
        } 
        #endregion


        #region Convert From Employee to EmployeeDomainModel
        /// <summary>
        /// Convert From Employee to EmployeeDomainModel
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static EmployeeDomainModel Map(Employee obj)
        {
            return new EmployeeDomainModel
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                HomePhone = obj.HomePhone,
                LastName = obj.LastName,
                Title = obj.Title
            };
        }

        /// <summary>
        /// Convert From Employee to EmployeeDomainModel
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static EmployeeDomainModel[] Map(List<Employee> objs)
        {
            return objs.ConvertAll(x => Map(x)).ToArray();
        } 
        #endregion

        #region Convert From ProductDomainModel To Product
        /// <summary>
        /// Convert From ProductDomainModel To Product
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Product Map(ProductDomainModel obj)
        {
            return new Product
            {
                ProductID = obj.ProductID,
                ProductName = obj.ProductName,
                UnitPrice = obj.UnitPrice
            };
        }

        /// <summary>
        /// Convert From ProductDomainModel To Product
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static Product[] Map(List<ProductDomainModel> objs)
        {
            // AWESOME!
            return objs.ConvertAll(x => Map(x)).ToArray();
        } 
        #endregion


        #region "FaultContract and Exception Mappers"

        public static FaultException<CustomException> MapFault(Exception ex)
        {
            return new FaultException<CustomException>(new CustomException
            {
                Message = ex.Message,
                Code = Guid.NewGuid().ToString(),
                StackTraceInfo = ex.StackTrace.ToString(),
            });
        }

        #endregion
    }
}
