using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace Northwind.WCFContracts.FaultContracts
{
    /// <summary>
    /// CustomException
    /// </summary>
    [DataContract(Name = "CustomException")]
    public class CustomException
    {
        /// <summary>
        /// ErrorTitle 
        /// </summary>
        [DataMember(Name = "Message", Order = 0)]
        public string Message { get; set; }

        /// <summary>
        /// ExceptionMessage 
        /// </summary>
        [DataMember(Name = "Code", Order = 1)]
        public string Code { get; set; }

        /// <summary>
        /// InnerException 
        /// </summary>
        [DataMember(Name = "StackTraceInfo", Order = 2)]
        public string StackTraceInfo { get; set; }

    }

}
