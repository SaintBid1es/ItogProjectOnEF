using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace ItogProjectOnEF
{
    /// <summary>
    /// Логика взаимодействия для SotrudnikiPage.xaml
    /// </summary>
    public partial class SotrudnikiPage : Page
    {
       EmployeeTableAdapter employee = new EmployeeTableAdapter();
        AdminSotrudnikiViewTableAdapter admin = new AdminSotrudnikiViewTableAdapter();
        public SotrudnikiPage()
        {
            InitializeComponent();
            SotridnikiDataGrid.ItemsSource = employee.GetData();
            RoleNameCbx.ItemsSource = employee.GetData();
            RoleNameCbx.DisplayMemberPath = "Roles_ID";
        }
        private static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string sb = "";
                for (int i = 0; i < hash.Length/4; i++)
                {
                    sb += hash[i].ToString("x2");
                }
                return sb;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            /* if (string.IsNullOrWhiteSpace(NameTxb.Text) || string.IsNullOrWhiteSpace(SurNameTxb.Text) || string.IsNullOrWhiteSpace(LastNameTxb.Text) || string.IsNullOrWhiteSpace(EmailTxb.Text) || string.IsNullOrWhiteSpace(TelephoneTxb.Text) || string.IsNullOrWhiteSpace(loginTxb.Text) || string.IsNullOrWhiteSpace(PasswordTxb.Password) || RoleNameCbx.SelectedItem == null)
             {
                 MessageBox.Show("Не все поля заполненны");
             }
             string input = NameTxb.Text;
             bool containsDigits = input.Any(char.IsDigit);
             if(containsDigits)
             {
                 MessageBox.Show("В поле Имя должно быть введены только буквы.");
                 NameTxb.Text = string.Empty;
             }
             string input1 = SurNameTxb.Text;
             bool containsDigits1 = input.Any(char.IsDigit);
             if (containsDigits1)
             {
                 MessageBox.Show("В поле Фамилия должны быть введены только буквы.");
                 SurNameTxb.Text = string.Empty;
             }
             string inpu3 = LastNameTxb.Text;
             bool containsDigits12 = input.Any(char.IsDigit);
             if (containsDigits12)
             {
                 MessageBox.Show("В поле Отчество быть введены только буквы.");
                 LastNameTxb.Text = string.Empty;
             }
             */
            if (RoleNameCbx.SelectedItem == null ||  string.IsNullOrWhiteSpace(NameTxb.Text) ||  string.IsNullOrWhiteSpace(SurNameTxb.Text) || string.IsNullOrWhiteSpace(LastNameTxb.Text) || string.IsNullOrWhiteSpace(EmailTxb.Text))
{
                MessageBox.Show("Не все данные заполнены");
                return;
            }
            if (SurNameTxb.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("В поле должны быть введены только буквы.");
                SurNameTxb.Text = string.Empty;
                return;
            }
            if (LastNameTxb.Text.Any(c => !char.IsLetter(c)))
            {
                MessageBox.Show("В поле должны быть введены только буквы.");
                LastNameTxb.Text = string.Empty;
                return;
            }
           
            if (RoleNameCbx != null)
            {
                employee.InsertQuery(NameTxb.Text, SurNameTxb.Text, LastNameTxb.Text, EmailTxb.Text, TelephoneTxb.Text, loginTxb.Text, Hash(PasswordTxb.Password), Convert.ToInt32(RoleNameCbx.Text));
                SotridnikiDataGrid.ItemsSource = employee.GetData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (SotridnikiDataGrid.SelectedItem as DataRowView).Row[0];
            employee.UpdateQuery(NameTxb.Text,SurNameTxb.Text,LastNameTxb.Text,EmailTxb.Text,TelephoneTxb.Text,loginTxb.Text,PasswordTxb.Password,Convert.ToInt32(id));
            SotridnikiDataGrid.ItemsSource = employee.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            object id = (SotridnikiDataGrid.SelectedItem as DataRowView).Row[0];
            employee.DeleteQuery(Convert.ToInt32(id));
            SotridnikiDataGrid.ItemsSource = employee.GetData();
        }
        
       private void SotridnikiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(SotridnikiDataGrid.SelectedItem != null)
            {
                var selected = SotridnikiDataGrid.SelectedItem as DataRowView;
                RoleNameCbx.Text = Convert.ToInt32(selected.Row[1]).ToString(); 
                NameTxb.Text = selected.Row[3] as string;
                SurNameTxb.Text = selected.Row[4] as string;
                LastNameTxb.Text = selected.Row[5] as string;
                EmailTxb.Text = selected.Row[6] as string;
                TelephoneTxb.Text = selected.Row[7] as string;
                loginTxb.Text = selected.Row[8] as string;
                PasswordTxb.Password = selected.Row[9] as string;
            }
        }
    }
}
