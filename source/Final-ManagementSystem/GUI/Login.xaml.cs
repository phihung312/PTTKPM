using Final_ManagementSystem.BUS;
using Final_ManagementSystem.DTO;
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

namespace Final_ManagementSystem.GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        List<TaiKhoan> tk = new List<TaiKhoan>();
        
        public Login()
        {
            InitializeComponent();
            TaiKhoan_Bus taiKhoan_Bus = new TaiKhoan_Bus();
            tk = taiKhoan_Bus.LoadAll();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (tk[0].TaiKhoan1 == UsernameText.Text && tk[0].MatKhau == PasswordText.Password)
            {
                Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Username/password was unavailble!", "Problem", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
