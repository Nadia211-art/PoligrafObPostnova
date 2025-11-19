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
    /// Логика взаимодействия для RentalPage.xaml
    /// </summary>
    public partial class RentalPage : Page
    {
        public RentalPage()
        {
            InitializeComponent();

            ClientCmb.SelectedValuePath = "Id";
            ClientCmb.DisplayMemberPath = "Fullname";
            ClientCmb.ItemsSource = App.context.User.ToList();
        }

        private void ArrangeLeaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClientCmb.Text) && string.IsNullOrEmpty(StartDateDp.Text) && string.IsNullOrEmpty(EndDateDp.Text) && string.IsNullOrEmpty(CostTb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Rental rental = new Rental()
                {
                    //IdUser = Convert.ToInt32(ClientCmb.SelectedItem as User),
                    StartDate = (DateTime)StartDateDp.SelectedDate,
                    EndDate = (DateTime)EndDateDp.SelectedDate,
                    Cost = Convert.ToDecimal(CostTb.Text)
                };

                App.context.Rental.Add(rental);
                App.context.SaveChanges();
                MessageBox.Show("Аренда добавлена");

                ClientCmb.Text = "";
                StartDateDp.Text = "";
                EndDateDp.Text = "";
                CostTb.Text = "";


            }
        }
    }
}
