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
    /// Логика взаимодействия для EditWorkerWindow.xaml
    /// </summary>
    public partial class EditWorkerWindow : Window
    {
        Worker workerworker;
        public EditWorkerWindow(Worker worker)
        {
            InitializeComponent();
            try
            {
                workerworker = worker;
                TbFirstName.Text = worker.FirstName;
                TbLastName.Text = worker.LastName;
                TbPatronymic.Text = worker.Patronymic;
                DpDate.Text = worker.Birthday.ToString();
                TbPhone.Text = worker.Phone;
                TbEmail.Text = worker.Email;
                DB.UserPassword userPassword = MyContext.UserPassword.ToList().Where(i => i.IdUserPassword == worker.IdUserPassword).FirstOrDefault();
                TbLogin.Text = userPassword.Login;
                TbPassword.Text = userPassword.Password;


                CbGender.ItemsSource = MyContext.Gender.ToList();
                CbGender.DisplayMemberPath = "NameGender";
                CbGender.SelectedItem = MyContext.Gender.ToList().Where(i => i.IdGender == worker.IdGender).FirstOrDefault();
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
                workerworker.IdGender = (CbGender.SelectedItem as Gender).IdGender;
                workerworker.FirstName = TbFirstName.Text;
                workerworker.LastName = TbLastName.Text;
                workerworker.Patronymic = TbPatronymic.Text;
                workerworker.Email = TbEmail.Text;
                workerworker.Phone = TbPhone.Text;
                workerworker.Birthday = Convert.ToDateTime(DpDate.Text);
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
            WorkerWindow worker = new WorkerWindow();
            worker.Show();
            this.Close();
        }

     
    }
}
