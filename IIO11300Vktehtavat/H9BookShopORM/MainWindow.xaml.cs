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

namespace H9BookShopORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void haeTestiKirjaButton_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan pari testi kirja-oliota jotta nähdään toimiiko ui
            books = BookShop.GetTestBooks();
            myDataGrid.DataContext = books;
        }

        private void HaeKirjatSQL_Click(object sender, RoutedEventArgs e)
        {
            // Haetaan kirjat tietokannasta
        }

        private void tallennaButton_Click(object sender, RoutedEventArgs e)
        {
            // Valittu Book-olio tallennetaan kantaan
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spBook.DataContext = myDataGrid.SelectedItem;
        }
    }
}
