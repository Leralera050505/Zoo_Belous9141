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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
            GetListWorker();

            listviewWorker.ItemsSource = MyContext.Worker.ToList();
        }
       private void GetListWorker()
        {
            List<Worker> workers = new List<Worker>();
            workers = MyContext.Worker.ToList();
            listviewWorker.ItemsSource = workers;
        }

        private void btnDelitWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker worker = listviewWorker.SelectedItem as Worker;
                UserPassword userPassword = MyContext.UserPassword.ToList().Where(i => i.IdUserPassword == worker.IdUserPassword).FirstOrDefault();
                MyContext.Worker.Remove(worker);
                MyContext.SaveChanges();
                MyContext.UserPassword.Remove(userPassword);
                MyContext.SaveChanges();
                listviewWorker.ItemsSource = MyContext.Worker.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReAdd_Click(object sender, RoutedEventArgs e)
        {
            EditWorkerWindow editWorkerWindow = new EditWorkerWindow(listviewWorker.SelectedItem as Worker);
            editWorkerWindow.Show();
            this.Close();
        }

        private void bntAddWork_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            addWorkerWindow.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
