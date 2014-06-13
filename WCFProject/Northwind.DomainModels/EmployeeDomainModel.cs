using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.DomainModels
{
    /// <summary>
    /// <para>
    /// EmployeeDomainModel represents data 
    /// from the employee table in the Northwind DB
    /// this class is a custom datatype to be used in the DAL and BLL.
    /// </para>
    /// <para>
    /// Service Layer should not be returning any domain model class.
    /// </para>
    /// </summary>
    public class EmployeeDomainModel
    {

        #region Automatic Public Properties

        /// <summary>
        /// <para>
        /// Employee ID - Unique identifier for the employee record in the Northwind database.
        /// </para>
        /// <para>
        /// Consider using a GUID datatype as primary key.
        /// </para>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Home Phone
        /// </summary>
        public string HomePhone { get; set; }     

        #endregion
    }
}
