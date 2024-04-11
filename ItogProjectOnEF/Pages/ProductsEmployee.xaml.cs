using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для ProductsEmployee.xaml
    /// </summary>
    public partial class ProductsEmployee : Page
    {
        ProductsTableAdapter product = new ProductsTableAdapter();
        public ProductsEmployee()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = product.GetData();
            Category_id_cbx.ItemsSource = product.GetData();
            Category_id_cbx.DisplayMemberPath = "Category_ID";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name_productTxb.Text) || string.IsNullOrWhiteSpace(propertyProductTxb.Text) || string.IsNullOrWhiteSpace(PriceTxb.Text))
            {
                MessageBox.Show("Не все данные заполнены");
    return;
            }
                if (!int.TryParse(PriceTxb.Text, out int price))
                {
                    MessageBox.Show("Цена должна быть числом");
                    return;
                }

            if (price < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной");
                return;
            }
            if (price > 2000000)
            {
                MessageBox.Show("Цена не может быть выше 2000000)");
                return;
            }
            
            

            string input = Name_productTxb.Text;

            bool containsDigits = input.Any(char.IsDigit);

            if (containsDigits)
            {
                MessageBox.Show("Должны быть введены только буквы.");
                Name_productTxb.Text = string.Empty;
            }
           
            string input1 = propertyProductTxb.Text;

            bool containsDigits1 = input.Any(char.IsDigit); 

            if (containsDigits1)
            {
                MessageBox.Show("Должны быть введены только буквы.");
                propertyProductTxb.Text = string.Empty;
            }

            if (!int.TryParse(PriceTxb.Text, out int price1))
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }

            if (price1 < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной");
                return;
            }
            if (price1 > 2000000)
            {
                MessageBox.Show("Цена не может быть выше 2000000)");
                return;
            }
            
            

            product.InsertQuery(Name_productTxb.Text, propertyProductTxb.Text, Convert.ToInt32(PriceTxb.Text), Convert.ToInt32(Category_id_cbx.Text));
            ProductsDataGrid.ItemsSource = product.GetData();
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            product.UpdateQuery(Name_productTxb.Text,propertyProductTxb.Text, Convert.ToInt32(PriceTxb.Text),Convert.ToInt32(id));
            ProductsDataGrid.ItemsSource = product.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            product.DeleteQuery(Convert.ToInt32(id));
            ProductsDataGrid.ItemsSource = product.GetData();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ProductsDataGrid.SelectedItem != null)
            {
                var selected = ProductsDataGrid.SelectedItem as DataRowView;
                Name_productTxb.Text = selected.Row[1] as string;
                propertyProductTxb.Text = selected.Row[2] as string;
                PriceTxb.Text = Convert.ToInt32(selected.Row[3]).ToString();
                Category_id_cbx.Text = Convert.ToInt32(selected.Row[3]).ToString();
            }

        }
    }
}
