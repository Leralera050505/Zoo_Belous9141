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
    /// Логика взаимодействия для SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public SaleWindow()
        {
            InitializeComponent();
            GetListSale();

            listviewSale.ItemsSource = MyContext.Sale.ToList();
        }

        private void GetListSale()
        {
            List<Sale> sales = new List<Sale>();
            sales = MyContext.Sale.ToList();
            listviewSale.ItemsSource = sales;
        }

     

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void bntAddSale_Click(object sender, RoutedEventArgs e)
        {
            AddSaleWindow addSaleWindow = new AddSaleWindow();
            addSaleWindow.Show();
            this.Close();
        }
    }
}
