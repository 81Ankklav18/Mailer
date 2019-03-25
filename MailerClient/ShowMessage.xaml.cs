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
    /// Interaction logic for ShowMessage.xaml
    /// </summary>
    public partial class ShowMessage : Window
    {
        private MailerApp.MailerService myService = new MailerService();
        public ShowMessage(string type, int message_id)
        {
            InitializeComponent();
            string message = myService.GetMessage(type, message_id);
            messageTB.Text = message;
        }
    }
}
