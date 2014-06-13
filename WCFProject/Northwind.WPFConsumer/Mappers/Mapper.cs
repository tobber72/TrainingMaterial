using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Northwind.WPFConsumer.ViewModels;
using Northwind.WPFConsumer.NorthwindServiceClasses;

namespace Northwind.WPFConsumer
{
    /// <summary>
    /// The mapper class will convert DATACONTRACTS into VIEWMODELS and visa versa
    /// </summary>
    public static class Mapper
    {


        #region Convert From EmployeeDomainModel To Employee
        public static EmployeeViewModel Map(NorthwindEmployee obj)
        {
            return new EmployeeViewModel
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                HomePhone = obj.HomePhone,
                LastName = obj.LastName,
                Title = obj.Title
            };
        }

        public static EmployeeViewModel[] Map(List<NorthwindEmployee> objs)
        {
            return objs.ConvertAll(x => Map(x)).ToArray();
        } 
        #endregion

        #region Convert From  Employee TO EmployeeDomainModel
        public static NorthwindEmployee Map(EmployeeViewModel obj)
        {
            return new NorthwindEmployee
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                HomePhone = obj.HomePhone,
                LastName = obj.LastName,
                Title = obj.Title
            };
        }

        public static NorthwindEmployee[] Map(List<EmployeeViewModel> objs)
        {
            return objs.ConvertAll(x => Map(x)).ToArray();
        }
        #endregion

        //#region Convert From Employee to EmployeeDomainModel
        //public static EmployeeDomainModel Map(Employee obj)
        //{
        //    return new EmployeeDomainModel
        //    {
        //        EmployeeId = obj.EmployeeId,
        //        FirstName = obj.FirstName,
        //        HomePhone = obj.HomePhone,
        //        LastName = obj.LastName,
        //        Title = obj.Title
        //    };
        //}

        //public static EmployeeDomainModel[] Map(List<Employee> objs)
        //{
        //    return objs.ConvertAll(x => Map(x)).ToArray();
        //} 
        //#endregion

        //#region Convert From ProductDomainModel To Product
        //public static Product Map(ProductDomainModel obj)
        //{
        //    return new Product
        //    {
        //        ProductID = obj.ProductID,
        //        ProductName = obj.ProductName,
        //        UnitPrice = obj.UnitPrice
        //    };
        //}

        //public static Product[] Map(List<ProductDomainModel> objs)
        //{
        //    // AWESOME!
        //    return objs.ConvertAll(x => Map(x)).ToArray();
        //} 
        //#endregion

    }
}
