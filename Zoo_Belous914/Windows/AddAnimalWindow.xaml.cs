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
    /// Логика взаимодействия для AddAnimalWindow.xaml
    /// </summary>
    public partial class AddAnimalWindow : Window
    {
        public AddAnimalWindow()
        {
            InitializeComponent();
            cmbTypeAnimal.ItemsSource = MyContext.TypeAnimal.ToList();
            cmbTypeAnimal.SelectedIndex = 0;
            cmbTypeAnimal.DisplayMemberPath = "NameAnimal";

            cmbAviary.ItemsSource = MyContext.Aviary.ToList();
            cmbAviary.SelectedIndex = 0;
            cmbAviary.DisplayMemberPath = "NameAviary";
        }

     
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = new Animal();
                animal.NameAnimal = TbAnimalName.Text;
                animal.IdTypeAnimsl = (cmbTypeAnimal.SelectedItem as DB.TypeAnimal).IdTypeAnimal;
                animal.IdAviary = (cmbAviary.SelectedItem as DB.Aviary).IdAviary;
                MyContext.Animal.Add(animal);

                MessageBox.Show("Добавление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            AnimalWindow animalWindow = new AnimalWindow();
            animalWindow.Show();
        }

    }
}
