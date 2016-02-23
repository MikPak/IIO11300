using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;

namespace XMLViinikellari
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Load default view to DataGrid
            XElement Viinit = XElement.Load("D:\\Viinit1.xml");
            dgWines.DataContext = Viinit;

            // Populate ComboBox
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Viinit1.xml");
            XmlNodeList wineList = doc.SelectNodes("viinikellari/wine/maa");
            foreach (XmlNode dataSources in wineList)
            {
                if (!maatComboBox.Items.Contains(dataSources.InnerText))
                {
                    maatComboBox.Items.Add(dataSources.InnerText);
                }
            }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            DataTable dt = new DataTable("Table1");
            dgWines.DataContext = dt;
            IBindingListView blv = dt.DefaultView;
            blv.Filter = "maa = 'MOISES'";
             * */
        }
    }
}
