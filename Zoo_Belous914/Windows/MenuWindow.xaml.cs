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

namespace Zoo_Belous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
            this.Close();
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow(); 
            workerWindow.Show();
            this.Close();
        }

        private void btnAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalWindow animalWindow = new AnimalWindow();
            animalWindow.Show();
            this.Close();
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            SaleWindow saleWindow = new SaleWindow();
            saleWindow.Show();
            this.Close();
        }

        private void btnTiket_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow ticketWindow = new TicketWindow();
            ticketWindow.Show();
            this.Close();
        }
    }
}
