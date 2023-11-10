using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        Client clientcleint;
        public EditClientWindow(Client client)
        {
        
            InitializeComponent();
            try
            {
                clientcleint = client;
                TbFirstName.Text = client.FirstName;
                TbLastName.Text = client.LastName;
                TbPatronymic.Text = client.Patronymic;
                DpDate.Text = client.Birthday.ToString();
                DB.UserPassword userPassword = MyContext.UserPassword.ToList().Where(i => i.IdUserPassword == client.IdUserPassword).FirstOrDefault();
                TbLogin.Text = userPassword.Login;
                TbPassword.Text = userPassword.Password;
            

                CbGender.ItemsSource =MyContext.Gender.ToList();
                CbGender.DisplayMemberPath = "NameGender";
                CbGender.SelectedItem = MyContext.Gender.ToList().Where(i => i.IdGender == client.IdGender).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientcleint.IdGender = (CbGender.SelectedItem as Gender).IdGender;
                clientcleint.FirstName = TbFirstName.Text;
                clientcleint.LastName = TbLastName.Text;
                clientcleint.Patronymic = TbPatronymic.Text;
                clientcleint.Birthday = Convert.ToDateTime(DpDate.Text);
                DB.UserPassword userPassword = new DB.UserPassword();
                userPassword.Login = userPassword.Login;
                userPassword.Password = userPassword.Password;
                MyContext.SaveChanges();
                MessageBox.Show("Сохранение прошло успешно");

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
