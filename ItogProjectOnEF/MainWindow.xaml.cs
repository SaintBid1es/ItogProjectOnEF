using System;
using System.Collections.Generic;
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
using ItogProjectOnEF.MAGAZINEDNSPR5DataSetTableAdapters;
namespace ItogProjectOnEF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      EmployeeTableAdapter employee = new EmployeeTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
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


        private void Autorizate_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = employee.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][8].ToString()==LoginTxb.Text && allLogins[i][9].ToString() == PasswordTxb.Password || allLogins[i][9].ToString() == Hash(PasswordTxb.Password))
                {
                    int roleID = (int)allLogins[i][1];
                    switch (roleID)
                    {
                        case 1:
                             adminWindow adminWindow = new adminWindow();
                             adminWindow.Show();
                              Close();
                            break;
                        case 2:
                            CustomersWindow customerWindow = new CustomersWindow();
                            customerWindow.Show();
                            Close();
                            break;
                        case 3:
                            EmployeeWindow employee = new EmployeeWindow();
                            employee.Show();
                            Close();
                            break;
                    }
                }

            }
            
        }
    }
}
