using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Northwind.WCFContracts.DataContract
{
    /// <summary>
    /// This is a product
    /// </summary>
    [DataContract (Name="NorthwindProduct")]
    public class Product
    {
        /// <summary>
        /// ProductID 
        /// </summary>
        [DataMember(Name = "ProductID", Order = 0, IsRequired = true)]
        public int ProductID { get; set; }

        /// <summary>
        /// ProductName 
        /// </summary>
        [DataMember(Name = "ProductName", Order = 1, IsRequired = false)]
        public string ProductName { get; set; }

        /// <summary>
        /// UnitPrice 
        /// </summary>
        [DataMember(Name = "UnitPrice", Order = 2, IsRequired = false)]
        public decimal UnitPrice { get; set; }



    }
}
