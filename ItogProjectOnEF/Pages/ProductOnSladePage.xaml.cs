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

namespace ItogProjectOnEF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductOnSladePage.xaml
    /// </summary>
    public partial class ProductOnSladePage : Page
    {
        ProductsOnSkladeTableAdapter productSklad = new ProductsOnSkladeTableAdapter();
        public ProductOnSladePage()
        {
            InitializeComponent();
            ProductOnSkladeDataGrid.SelectedItem = productSklad.GetData();
        }
    }
}
