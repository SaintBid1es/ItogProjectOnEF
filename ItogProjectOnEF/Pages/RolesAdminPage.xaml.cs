using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RolesAdminPage.xaml
    /// </summary>
    public partial class RolesAdminPage : Page
    {
        RolesTableAdapter roles = new RolesTableAdapter();
        public RolesAdminPage()
        {
            InitializeComponent();
            RolesDataGrid.ItemsSource = roles.GetData();
        }
        static bool ContainsInvalidSymbols(string input)
        {
            if (input.Contains('@') || input.Contains('#') || input.Contains('!'))
            {
                return true;
            }
            return false;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Contains("@") || (e.Text.Contains("%") || e.Text.Contains("#") || e.Text.Contains("!")|| e.Text.Contains("$") || e.Text.Contains("^") || e.Text.Contains("&") || e.Text.Contains("*")))
            {
                e.Handled = true; 
                MessageBox.Show("Ввод символов @, #, %, !, $, ^, &, *  недопустим."); 
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            roles.InsertQuery(RolesTxb.Text);
            RolesDataGrid.ItemsSource = roles.GetData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) 
        {
            object id = (RolesDataGrid.SelectedItem as DataRowView).Row[0];
            roles.UpdateQuery(RolesTxb.Text, Convert.ToInt32(id));
            RolesDataGrid.ItemsSource = roles.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (RolesDataGrid.SelectedItem as DataRowView).Row[0];
            roles.DeleteQuery(Convert.ToInt32(id));
            RolesDataGrid.ItemsSource = roles.GetData();
        }

        private void RolesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(RolesDataGrid.SelectedItem != null)
            {
                var selected = RolesDataGrid.SelectedItem as DataRowView;
                RolesTxb.Text = selected.Row[1] as string;
            }

        }
    }
}
