using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Northwind.WPFConsumer.ServiceGateways;
using Northwind.WPFConsumer.ViewModels;

namespace Northwind.WPFConsumer
{
    /// <summary>
    /// Interaction logic for InsertEmployeeWindow.xaml
    /// </summary>
    public partial class InsertEmployeeWindow : Window
    {
        public InsertEmployeeWindow()
        {
            InitializeComponent();
        }

        private void ButtonInsertEmployee_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            emp.FirstName = txtFirstName.Text;
            emp.LastName = txtLastName.Text;
            emp.Title = txtTitle.Text;
            emp.HomePhone = txtHomePhone.Text;

            DataGateway.InsertEmployee(emp);
        }
    }
}
