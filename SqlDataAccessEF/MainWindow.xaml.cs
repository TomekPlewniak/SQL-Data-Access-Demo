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

namespace SqlDataAccessEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SampleEntities db = new SampleEntities();

            List<Person> personsList = db.People.Where(x => x.LastName == LastNameText.Text).ToList();

            PeopleFoundListBox.ItemsSource = personsList;
            PeopleFoundListBox.DisplayMemberPath = "FullInfo";
        }
    }
}
