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
    /// Логика взаимодействия для AnimalWindow.xaml
    /// </summary>
    public partial class AnimalWindow : Window
    {
        public AnimalWindow()
        {
            InitializeComponent();
            GetListAnimal();
            listviewAnimal.ItemsSource = MyContext.Animal.ToList();
        }
        private void GetListAnimal()
        {
            List<Animal> animals = new List<Animal>();
            animals = MyContext.Animal.ToList();
            listviewAnimal.ItemsSource = animals;
        }

        private void btnDelitWork_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = listviewAnimal.SelectedItem as Animal;
            MyContext.Animal.Remove(animal);
            MyContext.SaveChanges();
            listviewAnimal.ItemsSource = MyContext.Animal.ToList();
        }

   

        private void bntAddWork_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalWindow addAnimalWindow = new AddAnimalWindow();
            addAnimalWindow.Show();
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
