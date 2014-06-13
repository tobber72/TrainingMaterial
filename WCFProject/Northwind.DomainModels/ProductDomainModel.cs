using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DomainModels
{
    /// <summary>
    /// <para>
    /// ProductDomainModel represents data 
    /// from the PRODUCTS table in the Northwind DB
    /// this class is a custom datatype to be used in the DAL and BLL.
    /// </para>
    /// <para>
    /// Service Layer should not be returning any domain model class.
    /// </para>
    /// </summary>
    public class ProductDomainModel
    {

        #region Automatic Public Properties

        /// <summary>
        /// <para>
        /// ProductID - Unique identifier for the Product record in the Northwind database.
        /// </para>
        /// <para>
        /// Consider using a GUID datatype as primary key.
        /// </para>
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// ProductName 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// UnitPrice 
        /// </summary>
        public decimal UnitPrice { get; set; }

        #endregion

    }
}
