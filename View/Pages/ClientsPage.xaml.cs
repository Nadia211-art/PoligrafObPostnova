using PoligrafObPostnova.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace PoligrafObPostnova.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();

            ClientTypeCmb.SelectedValuePath = "Id";
            ClientTypeCmb.DisplayMemberPath = "Name";
            ClientTypeCmb.ItemsSource = App.context.UserType.ToList();



        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientNameTb.Text) && string.IsNullOrEmpty(ClientTypeCmb.Text) && string.IsNullOrEmpty(PhoneTb.Text) && string.IsNullOrEmpty(EmailTb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                User user = new User()
                {
                    Fullname = ClientNameTb.Text,
                    Email = EmailTb.Text,
                    Phone = PhoneTb.Text,
                    UserType = ClientTypeCmb.SelectedItem as UserType
                };

                App.context.User.Add(user);
                App.context.SaveChanges();
                MessageBox.Show("Активность добавлена");

                ClientNameTb.Text = "";
                   EmailTb.Text = "";
                PhoneTb.Text = "";
                ClientTypeCmb.Text = "";


            }
        }
    }
}
