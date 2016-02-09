using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OudotOliot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelaaja> pelaajatList = new List<Pelaaja>();

        public MainWindow()
        {
            InitializeComponent();
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

        private void luoPelaajaBtn_Click(object sender, RoutedEventArgs e)
        {
            if(etunimiTxtBox.Text != "" && sukunimiTxtBox.Text != "" && siirtohintaTxtBox.Text != ""
                && seuraComboBox.SelectedItem != null)
            {
                try
                {
                    Pelaaja pelaaja = new Pelaaja(etunimiTxtBox.Text, sukunimiTxtBox.Text, 
                       seuraComboBox.SelectedItem.ToString(), siirtohintaTxtBox.Text);

                    //Console.WriteLine(pelaajatList.Count);
                    if (!pelaajatList.Any(x => x.Etunimi == pelaaja.Etunimi && x.Sukunimi == pelaaja.Sukunimi))
                    {
                        pelaajatListBox.Items.Add(pelaaja);
                        pelaajatList.Add(pelaaja);

                        //statusBar1.Text = "asd";
                        /*
                        System.Windows.pelaajatListBox.DisplayMember = "UserName";
                        pelaajatListBox.ValueMember = "UserId";

                        pelaajatListBox.Items.Add(new YourItem
                        {
                            UserName = "FooName",
                            UserId = "FooId"
                        });
                         */
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

                // Remove from List
                int index = pelaajatList.FindIndex(a => a.Etunimi == pelaaja.Etunimi && a.Sukunimi == pelaaja.Sukunimi);
                pelaajatList.RemoveAt(index);
                Console.WriteLine(pelaajatList.Count);

                // Reset pointer
                pelaaja = null;
                // Remove item from ListBox
                pelaajatListBox.Items.Remove(pelaajatListBox.SelectedItem);

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
    }
}
