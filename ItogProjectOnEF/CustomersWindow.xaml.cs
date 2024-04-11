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
    /// Логика взаимодействия для CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        public CustomersWindow()
        {
            InitializeComponent();
        }

        private void ProductBuy_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ProductsBuyPage();
        }

        private void Comments_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CommentsPage();
        }

        private void Sales_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new SalesPage();
        }

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new SuppliersPage();
        }
    }
}
