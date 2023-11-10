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
    /// Логика взаимодействия для AddTicketWindow.xaml
    /// </summary>
    public partial class AddTicketWindow : Window
    {
        public AddTicketWindow()
        {
            InitializeComponent();
            cmbTypeTicket.ItemsSource = MyContext.TypeTicket.ToList();
            cmbTypeTicket.SelectedIndex = 0;
            cmbTypeTicket.DisplayMemberPath = "TitleTicket";
        }

        private void btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket();
                ticket.Cost = Convert.ToDecimal(TbFullCost.Text);
                ticket.IdTypeTicket = (cmbTypeTicket.SelectedItem as DB.TypeTicket).IdTypeTicket;
                MyContext.Ticket.Add(ticket);
                MessageBox.Show("Добавление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            TicketWindow ticket = new TicketWindow();
            ticket.Show();
            this.Close();
        }
    }
}
