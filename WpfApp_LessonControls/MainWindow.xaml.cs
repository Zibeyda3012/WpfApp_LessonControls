using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp_LessonControls.Models;

namespace WpfApp_LessonControls
{
    public partial class MainWindow : Window
    {
        private List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            MyList.ItemsSource = people;
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string? name = null, surname = null, gender = null, city = null;
            bool isStep = false;

            if (txtName.Text is not null)
                name = txtName.Text;

            if (txtSurname.Text is not null)
                surname = txtSurname.Text;

            foreach (var item in GenderPanel.Children)
            {
                var gd = item as RadioButton;
                if (gd is not null && gd.IsChecked == true)
                {
                    gender = gd.Content.ToString();
                    break;
                }
            }

            if (CityChoice.SelectedItem is not null)
            {
                string txt = CityChoice.SelectedItem.ToString();
                string[] arr = txt.Split(':');
                int len = arr.Length;
                city = arr[len - 1];
            }


            if (step is not null)
                if (step.IsChecked == true)
                    isStep = true;


            Person newPerson = new Person(name, surname, gender, city, isStep);
            people.Add(newPerson);
            txtName.Text = "";
            txtSurname.Text = "";
            ((RadioButton)GenderPanel.Children[0]).IsChecked = true;
            CityChoice.SelectedItem = null;
            step.IsChecked = false;
            MyList.ItemsSource = null;
            MyList.ItemsSource = people;


        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            var JsonList = JsonSerializer.Serialize<List<Person>>(people);
            File.WriteAllText("../../../JsonFiles/myList.json", JsonList);
        }

        private void Remove_click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyList.SelectedItems)
            {
                var person = item as Person;
                if (person is not null)
                    people.Remove(person);

            }

            MyList.ItemsSource = null;
            MyList.ItemsSource = people;

        }
    }
}