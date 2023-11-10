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
using Zoo_Belous914.DB;
using static Zoo_Belous914.HelpClass.EFClass;

namespace Zoo_Belous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        public ClientListWindow()
        {
            InitializeComponent();
            GetLisClient();
            listviewWorker.ItemsSource = MyContext.Client.ToList();
        }

      private void  GetLisClient()
        {
            List<Client> client = new List<Client>();
            client = MyContext.Client.ToList();
            listviewWorker.ItemsSource = client;
        }

      


        private void btnReAdd_Click(object sender, RoutedEventArgs e)
        {
            EditClientWindow editClientWindow = new EditClientWindow(listviewWorker.SelectedItem as Client);
            editClientWindow.Show();
            this.Close();

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void bntAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            this.Close();
        }

        private void btnDelitClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = listviewWorker.SelectedItem as Client;
                UserPassword userPassword = MyContext.UserPassword.ToList().Where(i => i.IdUserPassword == client.IdUserPassword).FirstOrDefault();
                MyContext.Client.Remove(client);
                MyContext.SaveChanges();
                MyContext.UserPassword.Remove(userPassword);
                MyContext.SaveChanges();
                listviewWorker.ItemsSource = MyContext.Client.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
