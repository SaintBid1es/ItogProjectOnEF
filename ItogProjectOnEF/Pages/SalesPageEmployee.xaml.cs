using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
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
    /// Логика взаимодействия для SalesPageEmployee.xaml
    /// </summary>
    public partial class SalesPageEmployee : Page
    {
      SalesTableAdapter sales = new SalesTableAdapter();
        public SalesPageEmployee()
        {
            InitializeComponent();
            SalesDataGrid.ItemsSource = sales.GetData();
            Category_ID_Cbx.ItemsSource = sales.GetData();
            Category_ID_Cbx.DisplayMemberPath = "Category_ID";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Category_ID_Cbx.SelectedItem == null || string.IsNullOrWhiteSpace(SizeSkidkiTxb.Text) || string.IsNullOrWhiteSpace(Date_beginTxb.Text) || string.IsNullOrWhiteSpace(Date_endTxb.Text))
            {
                MessageBox.Show("Не все данные заполнены");
            }

            if (!int.TryParse(SizeSkidkiTxb.Text, out int amount))
            {
                MessageBox.Show("Скидка должна быть числом");
                return;
            }
            if (Category_ID_Cbx != null)
            {
                sales.InsertQuery(Convert.ToInt32(Category_ID_Cbx.Text), Convert.ToInt32(SizeSkidkiTxb.Text), Date_beginTxb.Text, Date_endTxb.Text);
                SalesDataGrid.ItemsSource = sales.GetData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (SalesDataGrid.SelectedItem as DataRowView).Row[0];
            sales.UpdateQuery(Convert.ToInt32(Category_ID_Cbx.Text), Convert.ToInt32(SizeSkidkiTxb.Text), Date_beginTxb.Text, Date_endTxb.Text, Convert.ToInt32(id));
            SalesDataGrid.ItemsSource = sales.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (SalesDataGrid.SelectedItem as DataRowView).Row[0];
            sales.DeleteQuery(Convert.ToInt32(id));
            SalesDataGrid.ItemsSource = sales.GetData();
        }

        private void SalesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SalesDataGrid.SelectedItem != null)
            {
                var selected = SalesDataGrid.SelectedItem as DataRowView;
                SizeSkidkiTxb.Text = Convert.ToInt32(selected.Row[2]).ToString();
                Date_beginTxb.Text = selected.Row[3] as string;
                Date_endTxb.Text = selected.Row[4] as string;
            }
        }
    }
}
