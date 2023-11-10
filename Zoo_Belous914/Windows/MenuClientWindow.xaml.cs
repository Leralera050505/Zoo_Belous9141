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
using static Zoo_Belous914.HelpClass.ClientClass;
using Zoo_Belous914.HelpClass;

namespace Zoo_Belous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuClientWindow.xaml
    /// </summary>
    public partial class MenuClientWindow : Window
    {
        public MenuClientWindow()
        {
            InitializeComponent();
            TbNAme.Text = ClientClass.Client.LastName + " " + ClientClass.Client.FirstName;
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
