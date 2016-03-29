using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace OudotOliot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajatList = new List<Pelaaja>();
        string constring = OudotOliot.Properties.Settings.Default.Tietokanta;

        public MainWindow()
        {
            InitializeComponent();
            iniMyStuff();
            initializeListBox();
        }

        /* Luo uuden pelaajan ja tallettaa ListBoxiin sekä tietokantaan */
        private void luoPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (etunimiTxtBox.Text != "" && sukunimiTxtBox.Text != "" && siirtohintaTxtBox.Text != ""
                && seuraComboBox.SelectedItem != null)
            {
                try
                {
                    int latestID = getLatestID();
                    if (latestID != 0)
                    {
                        Pelaaja pelaaja = new Pelaaja(latestID.ToString(), etunimiTxtBox.Text, sukunimiTxtBox.Text,
                           seuraComboBox.SelectedItem.ToString(), siirtohintaTxtBox.Text);

                        //Console.WriteLine(pelaajatList.Count);
                        if (!pelaajatList.Any(x => x.Etunimi == pelaaja.Etunimi && x.Sukunimi == pelaaja.Sukunimi))
                        {
                            pelaajatListBox.Items.Add(pelaaja);
                            pelaajatList.Add(pelaaja);
                            using (MySqlConnection conDataBase = new MySqlConnection(constring))
                            {
                                try
                                {
                                    conDataBase.Open();
                                    string query = @"INSERT INTO Players(Etunimi,Sukunimi,Seura,siirtohinta) values('"+pelaaja.Etunimi+"','"+pelaaja.Sukunimi+"','"+pelaaja.Seura+"','"+pelaaja.Siirtohinta+"');";
                                    MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                                    MySqlDataReader myReader = cmd.ExecuteReader();
                                    MessageBox.Show("Inserted to Database");
                                    conDataBase.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void talletaPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                Pelaaja pelaaja = (Pelaaja)pelaajatListBox.SelectedItem;
                pelaaja.Etunimi = etunimiTxtBox.Text;
                pelaaja.Sukunimi = sukunimiTxtBox.Text;
                pelaaja.Siirtohinta = siirtohintaTxtBox.Text;
                pelaaja.Seura = seuraComboBox.SelectedValue.ToString();
            }
        }

        private void poistaPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                Pelaaja pelaaja = (Pelaaja)pelaajatListBox.SelectedItem;

                // Remove item from ListBox
                pelaajatListBox.Items.Remove(pelaajatListBox.SelectedItem);

                using (MySqlConnection conDataBase = new MySqlConnection(constring))
                {
                    try
                    {
                        conDataBase.Open();
                        string query = "DELETE FROM Players WHERE Id='" + pelaaja.Id + "';";
                        MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                        MySqlDataReader myReader = cmd.ExecuteReader();
                        MessageBox.Show("Deleted from Database");
                        conDataBase.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // Reset text inputs
                etunimiTxtBox.Text = "";
                sukunimiTxtBox.Text = "";
                siirtohintaTxtBox.Text = "";
                seuraComboBox.SelectedIndex = -1;
            }
        }

        private void kirjoitaPelaajatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajatListBox.Items.Count != 0)
            {
                Microsoft.Win32.SaveFileDialog savefile = new Microsoft.Win32.SaveFileDialog();
                savefile.FileName = "Pelaajat";
                savefile.Filter = "Text files (*.dat)|*.dat|All files (*.*)|*.*";

                Nullable<bool> result = savefile.ShowDialog();
                if (result == true)
                {
                    //serialisoidaan XML:ksi
                    OudotOliot.Serialisointi.SerialisoiXml(@"D:\testi.xml", pelaajatList);
                }
            }
        }

        private void lopetusBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void seuraComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pelaajatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pelaajatListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                Pelaaja pelaaja = (Pelaaja)pelaajatListBox.SelectedItem;
                etunimiTxtBox.Text = pelaaja.Etunimi;
                sukunimiTxtBox.Text = pelaaja.Sukunimi;
                siirtohintaTxtBox.Text = pelaaja.Siirtohinta;
                int index = seuraComboBox.Items.IndexOf(pelaaja.Seura);
                //Console.WriteLine(index);
                seuraComboBox.SelectedIndex = index;
            }
        }

        private void iniMyStuff()
        {
            this.seuraComboBox.Items.Add("Blues");
            this.seuraComboBox.Items.Add("HIFK");
            this.seuraComboBox.Items.Add("HPK");
            this.seuraComboBox.Items.Add("Ilves");
            this.seuraComboBox.Items.Add("JYP");
            this.seuraComboBox.Items.Add("KalPa");
            this.seuraComboBox.Items.Add("KooKoo");
            this.seuraComboBox.Items.Add("Kärpät");
            this.seuraComboBox.Items.Add("Lukko");
            this.seuraComboBox.Items.Add("Pelicans");
            this.seuraComboBox.Items.Add("SaiPa");
            this.seuraComboBox.Items.Add("Sport");
            this.seuraComboBox.Items.Add("Tappara");
            this.seuraComboBox.Items.Add("TPS");
            this.seuraComboBox.Items.Add("Ässät");
        }

        private void initializeListBox()
        {
            pelaajatListBox.Items.Clear();
            string Query = "Select * FROM Players";
            using (MySqlConnection conDataBase = new MySqlConnection(constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader myReader = cmdDataBase.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string id = myReader["Id"].ToString();
                            string etunimi = myReader["Etunimi"].ToString();
                            string sukunimi = myReader["Sukunimi"].ToString();
                            string seura = myReader["Seura"].ToString();
                            string siirtohinta = myReader["Siirtohinta"].ToString();
                            Pelaaja pelaaja = new Pelaaja(id, etunimi, sukunimi, seura, siirtohinta);
                            pelaajatListBox.Items.Add(pelaaja);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void fetchFromDBBtn_Click(object sender, RoutedEventArgs e)
        {
            initializeListBox();
        }

        /* Saves listbox to database */
        private void saveToDBBtn_Click(object sender, RoutedEventArgs e)
        {
            getLatestID();
            using (MySqlConnection conDataBase = new MySqlConnection(constring))
            {
                try
                {
                    foreach (Pelaaja pelaaja in pelaajatListBox.Items)
                    {
                        conDataBase.Open();
                        string query = @"UPDATE Players SET Etunimi='"+pelaaja.Etunimi+"', Sukunimi='"+pelaaja.Sukunimi+"', Seura='"+pelaaja.Seura+"', siirtohinta='"+pelaaja.Siirtohinta+"' WHERE Id ='"+pelaaja.Id+"'";
                        MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                        MySqlDataReader myReader = cmd.ExecuteReader();
                        MessageBox.Show("Data Updated");
                        conDataBase.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /* Palauttaa viimeisimmän ID:n tietokannasta */
        private int getLatestID()
        {
            string Query = "Select MAX(Id) as Id FROM Players";
            using (MySqlConnection conDataBase = new MySqlConnection(constring))
            using (MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
            {
                try
                {
                    conDataBase.Open();
                    using (MySqlDataReader myReader = cmdDataBase.ExecuteReader())
                    {
                        myReader.Read();
                        string id = myReader["Id"].ToString();
                        //MessageBox.Show(id);
                        return Int32.Parse(id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
    }
}
