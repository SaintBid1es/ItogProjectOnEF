using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
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

namespace ItogProjectOnEF
{
    /// <summary>
    /// Логика взаимодействия для ProductsBuyPage.xaml
    /// </summary>
    public partial class ProductsBuyPage : Page
    {
        CustomersPokupkaViewTableAdapter customers = new CustomersPokupkaViewTableAdapter();
      
        public ProductsBuyPage()
        {
            InitializeComponent();
            ProductsBuyDataGrid.ItemsSource = customers.GetData();
            OrdersDataGrid.ItemsSource = customers.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
