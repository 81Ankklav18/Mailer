using MailerApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace MailerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Вход под учётной записью SQL Server.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTB.Text;
            string password = pwdTB.Text;
            MailerApp.MailerService myService = new MailerService();
            myService.Connect(login, password);

            Window1 w1 = new Window1(login);
            w1.Show();
            this.Close();
        }

        //Регистрация, если учетная запись не создана.
        //Отсутствует обработка исключения.
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}
