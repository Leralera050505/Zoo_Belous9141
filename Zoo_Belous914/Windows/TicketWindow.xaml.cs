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
    /// Логика взаимодействия для TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public TicketWindow()
        {
            InitializeComponent();
            listviewTicket.ItemsSource = MyContext.Ticket.ToList();
        }
        private void GetListTicket()
        {
            List<Animal> animals = new List<Animal>();
            animals = MyContext.Animal.ToList();
            listviewTicket.ItemsSource = animals;
        }

      
       

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void bntAddTicket_Click(object sender, RoutedEventArgs e)
        {
            AddTicketWindow addTicketWindow = new AddTicketWindow();
            addTicketWindow.Show(); 
            this.Close();
        }

        private void btnDelitTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticket = listviewTicket.SelectedItem as Ticket;

                MyContext.Ticket.Remove(ticket);
                MyContext.SaveChanges();
                listviewTicket.ItemsSource = MyContext.Ticket.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
