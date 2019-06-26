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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlDataAccessDapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            people = db.GetPeople(LastNameText.Text);

            PeopleFoundListBox.ItemsSource = people;
            PeopleFoundListBox.DisplayMemberPath = "FullInfo";

            FoundText.Text = people.Count().ToString();
        }
    }
}
