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
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        CommentsTableAdapter comments = new CommentsTableAdapter();
        ProductsTableAdapter products = new ProductsTableAdapter();
        public CommentsPage()
        {
            InitializeComponent();
            CommentsDataGrid.ItemsSource = comments.GetData();
            ProductIdCbx.ItemsSource = comments.GetData();
            ProductIdCbx.DisplayMemberPath = "Products_ID";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            comments.InsertQuery(Convert.ToInt32(ProductIdCbx.Text),TextTxb.Text,Convert.ToInt32(RatingTxb.Text));
            CommentsDataGrid.ItemsSource = comments.GetData();
        }

    }
}
