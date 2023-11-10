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
    /// Логика взаимодействия для AddSaleWindow.xaml
    /// </summary>
    public partial class AddSaleWindow : Window
    {
        public AddSaleWindow()
        {
            InitializeComponent();
            cmbClient.ItemsSource = MyContext.Client.ToList();
            cmbClient.SelectedIndex = 0;
            cmbClient.DisplayMemberPath = "LastName";
        }

        private void btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sale sale = new Sale();
                sale.FullCost = Convert.ToDecimal(TbFullCost.Text);
                sale.SaleDate = DateSale.SelectedDate.Value;
                sale.IdClient  = (cmbClient.SelectedItem as DB.Client).IdClient;
                MyContext.Sale.Add(sale);
                MessageBox.Show("Заказ добавлен успешно");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            SaleWindow sale = new SaleWindow();
            sale.Show();
            this.Close();
        }
    }
}
