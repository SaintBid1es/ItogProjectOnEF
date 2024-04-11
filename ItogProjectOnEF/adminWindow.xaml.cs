using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для adminWindow.xaml
    /// </summary>
    public partial class adminWindow : Window
    {
        public adminWindow()
        {
            InitializeComponent();
        }

     

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new RolesAdminPage();
        }

        private void Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new SotrudnikiPage();
        }

      

       
    }
}
