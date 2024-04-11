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
using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
namespace ItogProjectOnEF
{
    /// <summary>
    /// Логика взаимодействия для DataAutorizatePage.xaml
    /// </summary>
    public partial class DataAutorizatePage : Page
    {
        EmployeeAccountDataTableAdapter employee = new EmployeeAccountDataTableAdapter();

        public DataAutorizatePage()
        {
            InitializeComponent();
            DataAutorizateDataGrid.ItemsSource = employee.GetData();
            RoleID_Cbx.ItemsSource = employee.GetData();
            RoleID_Cbx.DisplayMemberPath = "RoleName";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            employee.InsertQuery(LoginTxb.Text,PasswordTxb.Password,RoleID_Cbx.Text);
            DataAutorizateDataGrid.ItemsSource = employee.GetData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataAutorizateDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataAutorizateDataGrid.SelectedItem != null)
            {
                var selected = DataAutorizateDataGrid.SelectedItem as DataRowView;
                LoginTxb.Text = selected.Row[1] as string;
                RoleID_Cbx.Text = selected.Row[3] as string;
            }
        }
    }
}
