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

            EquipmentTypeCmb.SelectedValuePath = "Id";
            EquipmentTypeCmb.DisplayMemberPath = "Name";
            EquipmentTypeCmb.ItemsSource=App.context.EquipmentType.ToList();

            ModelCmb.SelectedValuePath = "Id";
            ModelCmb.DisplayMemberPath= "Name";
            ModelCmb.ItemsSource = App.context.Equipment.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EquipmentTypeCmb.Text) && string.IsNullOrEmpty(ModelCmb.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Equipment equipment = new Equipment()
                {
                    Name = Convert.ToString(ModelCmb.SelectedItem as Equipment),
                    EquipmentType = EquipmentTypeCmb.SelectedItem as EquipmentType
                };

                App.context.Equipment.Add(equipment);
                App.context.SaveChanges();
                MessageBox.Show("Оборудование добавлено");

                EquipmentTypeCmb.Text = "";
                ModelCmb.Text = "";


            }
        }
    }
}
