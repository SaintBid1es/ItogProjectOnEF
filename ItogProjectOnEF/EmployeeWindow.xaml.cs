
using ItogProjectOnEF.Pages;
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

namespace ItogProjectOnEF
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        
        public EmployeeWindow()
        {
            InitializeComponent();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductsEmployee();
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new SalesPageEmployee();
        }
    }
}
