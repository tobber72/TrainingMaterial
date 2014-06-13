using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Northwind.WCFContracts.DataContract
{
    /// <summary>
    /// The Employee class is known as a data contract.
    /// also know as a DTO - data transfer object.
    /// are serializable custom data types that will be used to 
    /// define the method signatures of your service.
    /// </summary>
    [DataContract (Name="NorthwindEmployee")]    
    public class Employee
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        [DataMember(Name = "EmployeeId", Order = 0, IsRequired = true)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [DataMember(Name = "LastName", Order = 1, IsRequired = false)]
        public string LastName { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        [DataMember(Name = "FirstName", Order = 2, IsRequired = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [DataMember(Name = "Title", Order = 3, IsRequired = false)]
        public string Title { get; set; }

        /// <summary>
        /// HomePhone
        /// </summary>
        [DataMember(Name = "HomePhone", Order = 4, IsRequired = false)]
        public string HomePhone { get; set; }

    }
}
