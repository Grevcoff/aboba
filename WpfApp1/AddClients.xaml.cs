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
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        doka2Entities context;
        public AddClients(doka2Entities context, Client client)
        {
            InitializeComponent();
            Cmb.ItemsSource = context.Gender.ToList();
            this.context = context;
            this.DataContext = client;
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
