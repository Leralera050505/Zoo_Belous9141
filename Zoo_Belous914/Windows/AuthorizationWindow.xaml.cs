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
using static Zoo_Belous914.HelpClass.EFClass;

namespace Zoo_Belous914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

   
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
            }
            else if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show(" Пароль не может быть пустым");
            }
            else
            {
                try
                {
                    var auth = MyContext.UserPassword.ToList()
                    .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();

                    var Worker = MyContext.Worker.ToList().Where(i => i.UserPassword.Login == TbLogin.Text).FirstOrDefault();
                    var Client = MyContext.Client.ToList().Where(i => i.UserPassword.Login == TbLogin.Text).FirstOrDefault();
                    if ((auth != null) && (Worker != null))
                    {
                        //сохраняем пользователя в системе
                        HelpClass.WorksClass.Worker = Worker;
                        //Переходим на главную страницу
                        MenuWindow menuWindow = new MenuWindow();
                        menuWindow.Show();
                        this.Close();
                    }
                    else if ((auth != null) && (Client != null))
                    {
                        MenuClientWindow menuClient = new MenuClientWindow();
                        menuClient.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
