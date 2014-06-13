using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Northwind.WCFContracts.FaultContracts
{
    /// <summary>
    /// <para>
    /// Product Fault Exception:
    /// </para>
    /// </summary>
    [DataContract(Name = "ProductFaultException", Namespace = "urn:principal.com:schemas:pgi:training:2013-02-11")]
    public class ProductFaultException
    {

        /// <summary>
        /// ErrorTitle
        /// </summary>
        [DataMember()]
        public string ErrorTitle { get; set; }

        //[DataMember()]
        //public string ExceptionMessage { get; set; }

        //[DataMember()]
        //public string InnerException { get; set; }

        //[DataMember()]
        //public string InnerExceptionStackTrace { get; set; }

        //[DataMember()]
        //public Northwind.WCFContracts.DataContract.Product[] Product { get; set; }

    }
}
