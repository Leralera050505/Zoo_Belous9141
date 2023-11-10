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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        public AddWorkerWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = MyContext.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "NameGender";
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
          
                UserPassword userPassword = new UserPassword();
                userPassword.Login = TbLogin.Text;
                userPassword.Password = TbPassword.Text;
                MyContext.UserPassword.Add(userPassword);
            MyContext.SaveChanges();
            Worker worker = new Worker();
                worker.FirstName = TbFirstName.Text;
                worker.LastName = TbLastName.Text;
                worker.Patronymic = TbPatronymic.Text;
                worker.Birthday = DPDate.SelectedDate.Value;
                worker.Email = TbEmail.Text;
                worker.Phone = TbPhone.Text;
                worker.IdGender = (cmbGender.SelectedItem as DB.Gender).IdGender;
                worker.IdUserPassword = MyContext.UserPassword.ToList().Where(i => i.Login == 
                userPassword.Login).FirstOrDefault().IdUserPassword;
                MyContext.Worker.Add(worker);
                MyContext.SaveChanges();
                MessageBox.Show("Добавление прошло успешно");
           
           

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow worker = new WorkerWindow();
            worker.Show();
            this.Close();
        }
    }
}
