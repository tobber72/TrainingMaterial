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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Northwind.WPFConsumer.NorthwindServiceClasses;
using Northwind.WPFConsumer.ServiceGateways;
using Northwind.WPFConsumer.ViewModels;

namespace Northwind.WPFConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            #region call service to test connectivity

            //// Create a Proxy Object to communicate with the wcf service.
            //NorthwindServiceContractClient proxy = new NorthwindServiceContractClient();

            //// Call the Select Employeee Method of the service and handle the return.
            //NorthwindEmployee[] employees = proxy.SelectEmployees();

            //// always close the proxy object
            //proxy.Close();

            ////Display the Lastname of th First Employee in a messagebox
            //// MessageBox.Show("Last Name {0}", employees[0].LastName);
            //MessageBox.Show(employees[0].LastName);
            
            #endregion


            string[] titles = DataGateway.SelectEmployeeTitles();
            foreach (string tl in titles)
            {
                combobox1.Items.Add(tl);
            }         
        
        }

        private void buttonEmployees_Click_1(object sender, RoutedEventArgs e)
        {

            EmployeeViewModel[] employees = DataGateway.SelectEmployees();

            foreach (EmployeeViewModel emp in employees)
            {
                listboxEmployeData.Items.Add(emp.FullName);
            }

        }

        private void combobox1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            listboxEmployeData.Items.Clear();

            string title;
            title = combobox1.SelectedValue.ToString();
            EmployeeViewModel[] employees = DataGateway.SelectEmployeesByTitle(title);

            foreach (EmployeeViewModel emp in employees)
            {
                listboxEmployeData.Items.Add(emp.FullName);
            }

        }
    }
}
