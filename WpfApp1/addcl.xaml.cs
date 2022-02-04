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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для addcl.xaml
    /// </summary>
    public partial class addcl : Window
    {
        doka2Entities context;
        public addcl()
        {
            InitializeComponent();
            context = new doka2Entities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridClient.ItemsSource = context.Client.ToList();
        }

        private void BtnAddTables(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new Window1();
            RentalSelect.ShowDialog();
        }

        private void BtnEditData_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentRental = DataGridClient.SelectedItem as Client;
            if (currentRental == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("удадить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Client.Remove(currentRental);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewRental = new Client();
            context.Client.Add(NewRental);
            var AddClients = new AddClients(context, NewRental);
            AddClients.ShowDialog();
        }

        private void BtnAddClientService_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new Window1();
            RentalSelect.ShowDialog();
        }

        private void DataGridClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
