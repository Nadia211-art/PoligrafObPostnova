using PoligrafObPostnova.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PoligrafObPostnova.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentPage()
        {
            InitializeComponent();

            EquipmentTypeCmb
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
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
