using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WPFConsumer.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeViewModel
    {
        #region Automatic Public Properties

        public int EmployeeId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }

        public string HomePhone { get; set; }

        #endregion

        public string FullName 
        {
            get 
            {
                return string.Format("{0}, {1}", LastName, FirstName);
            }
        }

    }
}
