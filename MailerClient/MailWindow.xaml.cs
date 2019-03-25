using MailerApp;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Binding = System.Windows.Data.Binding;
using ComboBox = System.Windows.Controls.ComboBox;

namespace MailerClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MailerApp.MailerService myService = new MailerService();
        public Window1(string login)
        {
            InitializeComponent();
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            messagesGrid.RowStyle = rowStyle;

            helloLabel.Content = "Hello, " + login;
        }

        //Обновление данных
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            messagesGrid.ItemsSource = myService.GetData(mailList.Text).DefaultView;
        }

        //Создание сообщения
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateMail cm = new CreateMail();
            cm.Show();
        }

        //Завершение текущей сессии
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myService.LogOut();
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        //При двойном нажатии -- текст письма
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = messagesGrid.SelectedItem as DataRowView;
            int message_id = (int)row.Row["message_id"];
            ShowMessage sm = new ShowMessage(mailList.Text, message_id);
            sm.Show();
        }

        //Тип сообщения -- входящее или исходящее
        private void mailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            messagesGrid.ItemsSource = myService.GetData(selectedItem.Text).DefaultView;
        }
    }
}
