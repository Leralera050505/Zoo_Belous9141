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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = MyContext.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "NameGender";

        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                UserPassword userPassword = new UserPassword();
                userPassword.Login = TbLogin.Text;
                userPassword.Password = TbPassword.Text;
                MyContext.UserPassword.Add(userPassword);
                MyContext.SaveChanges();

                Client client = new Client();

                client.FirstName = TbFirstName.Text;
                client.LastName = TbLastName.Text;
                client.Patronymic = TbPatronymic.Text;
                client.Birthday = DPDate.SelectedDate.Value;

                client.IdGender = (cmbGender.SelectedItem as DB.Gender).IdGender;   
                client.IdUserPassword = MyContext.UserPassword.ToList().Where(i => i.Login == 
                userPassword.Login).FirstOrDefault().IdUserPassword;
                MyContext.Client.Add(client);
                MyContext.SaveChanges();

                MessageBox.Show("Добавление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
            this.Close();
        }
    }
}
