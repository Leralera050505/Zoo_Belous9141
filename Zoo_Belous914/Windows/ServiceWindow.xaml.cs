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
using static Zoo_Belous914.HelpClass.EFClass;

namespace Zoo_Belous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            CmbTypeTicket.ItemsSource = MyContext.TypeTicket.ToList();
            CmbTypeTicket.SelectedIndex = 0;
            CmbTypeTicket.DisplayMemberPath = "TitleTicket";

            CmbProduct.ItemsSource = MyContext.Product.ToList();
            CmbProduct.SelectedIndex = 0;
            CmbProduct.DisplayMemberPath = "NameProduct";


        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
