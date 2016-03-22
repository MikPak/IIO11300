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

namespace ViiniAsiakkaatCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataView dv;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void haeAsiakkaatButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta);
                using (SqlConnection conn =
                  new SqlConnection(ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                {
                    string sql = "SELECT * FROM customer";
                    //MessageBox.Show(sql);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dt = new DataTable();
                    dv = dt.DefaultView;
                    da.Fill(dt);
                    myDataGrid.DataContext = dt;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void teeUusiButton_Click(object sender, RoutedEventArgs e)
        {
            var etunimiTextBox = new TextBox();
            var sukunimiTextBox = new TextBox();
            var osoiteTextBox = new TextBox();
            var postinumeroTextBox = new TextBox();
            var kaupunkiTextBox = new TextBox();

            var etunimiLabel = new Label();
            var sukunimiLabel = new Label();
            var osoiteLabel = new Label();
            var postinumeroLabel = new Label();
            var kaupunkiLabel = new Label();

            var luoUusiButton = new Button();

            teeUusiHolder.Children.Add(etunimiLabel);
            etunimiLabel.Content = "Etunimi";
            teeUusiHolder.Children.Add(etunimiTextBox);
            etunimiTextBox.Width = 50;

            teeUusiHolder.Children.Add(sukunimiLabel);
            sukunimiLabel.Content = "Sukunimi";
            teeUusiHolder.Children.Add(sukunimiTextBox);
            sukunimiTextBox.Width = 50;

            teeUusiHolder.Children.Add(osoiteLabel);
            osoiteLabel.Content = "Osoite";
            teeUusiHolder.Children.Add(osoiteTextBox);
            osoiteTextBox.Width = 50;

            teeUusiHolder.Children.Add(postinumeroLabel);
            postinumeroLabel.Content = "Postinro";
            teeUusiHolder.Children.Add(postinumeroTextBox);
            postinumeroTextBox.Width = 50;

            teeUusiHolder.Children.Add(kaupunkiLabel);
            kaupunkiLabel.Content = "Kaupunki";
            teeUusiHolder.Children.Add(kaupunkiTextBox);
            kaupunkiTextBox.Width = 50;

            teeUusiHolder.Children.Add(luoUusiButton);
            luoUusiButton.Content = "Luo uusi";
            luoUusiButton.Margin = new System.Windows.Thickness(5, 0, 0, 0);
            luoUusiButton.Click += delegate
            {
                if (etunimiTextBox.Text != "" && sukunimiTextBox.Text != "" && osoiteTextBox.Text != "" &&
                    postinumeroTextBox.Text != "" && kaupunkiTextBox.Text != "")
                {
                    try
                    {
                        using (SqlConnection conn =
                            new SqlConnection(ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                        {

                            string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", etunimiTextBox.Text, sukunimiTextBox.Text, osoiteTextBox.Text, postinumeroTextBox.Text, kaupunkiTextBox.Text);
                            //MessageBox.Show(sql);
                            SqlCommand command = new SqlCommand(sql, conn);
                            conn.Open();
                            if (command.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Lisättiin onnistuneesti");
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
         }

        private void poistaValittuButton_Click(object sender, RoutedEventArgs e)
        {
            if(myDataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < myDataGrid.SelectedItems.Count; i++)
                {
                    System.Data.DataRowView selectedFile = (System.Data.DataRowView)myDataGrid.SelectedItems[i];
                    string str = Convert.ToString(selectedFile.Row.ItemArray[0]);
                    //MessageBox.Show(str);
                    try
                    {
                        using (SqlConnection conn =
                            new SqlConnection(ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                        {

                            string sql = string.Format("DELETE FROM customer WHERE ID='{0}'", str);
                            SqlCommand command = new SqlCommand(sql, conn);
                            conn.Open();
                            if (command.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Poistettiin onnistuneesti");
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void tallennaMuutoksetButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
