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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        doka2Entities context;
        public Window1()
        {
            InitializeComponent();
            context = new doka2Entities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridClientService.ItemsSource = context.ClientService.ToList();
        }

        private void BtnAddData_Click_1(object sender, RoutedEventArgs e)
        {
            var NewClientServ = new ClientService();
            context.ClientService.Add(NewClientServ);
            var btnAddClientServ2 = new Window2(context, NewClientServ);
            btnAddClientServ2.ShowDialog();
        }

        private void BtnDeleteData_Click_1(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridClientService.SelectedItem as ClientService;
            if (currentClientService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientService.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click_1(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as ClientService;
            var EdiWindow = new Window3(context, currentRental);
            EdiWindow.ShowDialog();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var RentalSel = new addcl();
            RentalSel.ShowDialog();
        }

        private void DataGridClientService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
