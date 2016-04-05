using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace SMLiigaEF
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Pelaajat> localPlayers;
        SMLiigaEntities smLiigaEntity = new SMLiigaEntities();

        public MainWindow()
        {
            InitializeComponent();
            iniMyStuff();
        }

        private void iniMyStuff()
        {
            // Initialize ComboBox values
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

            smLiigaEntity.Pelaajat.Load(); // Load table
            localPlayers = smLiigaEntity.Pelaajat.Local; // Read table to ObservableCollection<Pelaajat>

            // Fill ListBox with Pelaajat-objects
            pelaajatListBox.DataContext = localPlayers;
        }

        // Create new player and save object to ObservableCollection and data to database
        private void luoPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (etunimiTxtBox.Text != "" && sukunimiTxtBox.Text != "" && siirtohintaTxtBox.Text != ""
                && seuraComboBox.SelectedItem != null)
            {
                Pelaajat pelaaja = new Pelaajat();
                pelaaja.etunimi = etunimiTxtBox.Text;
                pelaaja.sukunimi = sukunimiTxtBox.Text;
                pelaaja.arvo = Convert.ToDouble(siirtohintaTxtBox.Text);
                pelaaja.seura = seuraComboBox.SelectedItem.ToString();
                localPlayers.Add(pelaaja);
                smLiigaEntity.SaveChanges();
            }
        }

        // Update player's data in DB
        private void talletaPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                Pelaajat pelaaja = (Pelaajat)pelaajatListBox.SelectedItem;
                pelaaja.etunimi = etunimiTxtBox.Text;
                pelaaja.sukunimi = sukunimiTxtBox.Text;
                pelaaja.arvo = Convert.ToDouble(siirtohintaTxtBox.Text);
                pelaaja.seura = seuraComboBox.SelectedValue.ToString();
            }
        }

        // Remove player from DB
        private void poistaPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                // Remove from DB
                int selectedIndex = pelaajatListBox.SelectedIndex;
                localPlayers.RemoveAt(selectedIndex);
                smLiigaEntity.SaveChanges();

                // Reset text inputs
                etunimiTxtBox.Text = "";
                sukunimiTxtBox.Text = "";
                siirtohintaTxtBox.Text = "";
                seuraComboBox.SelectedIndex = -1;
            }
        }

        /* 
            Add event listener for adding new players, everytime ComboBox selection changes,
            we check if required fields are not empty and if we should enable button for click.
        */
        private void seuraComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (etunimiTxtBox.Text != "" && sukunimiTxtBox.Text != "" && siirtohintaTxtBox.Text != ""
                && seuraComboBox.SelectedItem != null)
            {
                luoPelaajaBtn.IsEnabled = true;
            }
        }

        private void pelaajatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pelaajatListBox.SelectedItem != null)
            {
                poistaPelaajaBtn.IsEnabled = true;
                talletaPelaajaBtn.IsEnabled = true;

                Pelaajat pelaaja = (Pelaajat)pelaajatListBox.SelectedItem;
                etunimiTxtBox.Text = pelaaja.etunimi;
                sukunimiTxtBox.Text = pelaaja.sukunimi;
                siirtohintaTxtBox.Text = pelaaja.arvo.ToString();
                int index = seuraComboBox.Items.IndexOf(pelaaja.seura);
                //Console.WriteLine(index);
                seuraComboBox.SelectedIndex = index;
                smLiigaEntity.SaveChanges();
            }
        }
        private void lopetusBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void fetchFromDBBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void saveToDBBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
