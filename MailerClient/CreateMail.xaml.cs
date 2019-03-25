using MailerApp;
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

namespace MailerClient
{
    /// <summary>
    /// Interaction logic for CreateMail.xaml
    /// </summary>
    public partial class CreateMail : Window
    {
        private MailerApp.MailerService myService = new MailerService();
        
        public CreateMail()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myService.CreateMessage(message_name.Text, addressee.Text, tags.Text, message.Text);
            this.Close();
        }
    }
}
