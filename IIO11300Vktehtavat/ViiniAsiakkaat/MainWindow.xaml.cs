using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ViiniAsiakkaat
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


        private void haeAsiakkaatBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(ViiniAsiakkaat.Properties.Settings.Default.Tietokanta);
                using (SqlConnection conn =
                  new SqlConnection(ViiniAsiakkaat.Properties.Settings.Default.Tietokanta))
                {
                    string sql = "SELECT * FROM vCustomers";
                    //MessageBox.Show(sql);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("ViiniAsiakkaat");
                    da.Fill(dt);
                    myGrid.DataContext = dt;
                    myGrid.Columns[2].Visibility = Visibility.Hidden;
                    myGrid.Columns[3].Visibility = Visibility.Hidden;
                    myGrid.Columns[1].Visibility = Visibility.Hidden;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView drv = (DataRowView)myGrid.SelectedItem;
            String etunimi = (drv["firstname"]).ToString();
            String sukunimi = (drv["lastname"]).ToString();
            String osoite = (drv["address"]).ToString();
            String kaupunki = (drv["city"]).ToString();
            etunimiContentLabel.Content = etunimi;
            sukunimiContentLabel.Content = sukunimi;
            osoiteContentLabel.Content = osoite;
            kaupunkiContentLabel.Content = kaupunki;

        }
    }
}
