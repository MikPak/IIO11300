/*
* Copyright (C) JAMK/IT/Mikko Pakkanen
* This file is part of the IIO11300 course project.
* Created: 27.1.2016 Modified xx.xx.xxxx
* Authors: Mikko Pakkanen
*/

using System;
using System.IO;
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
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using JAMK.IT.IIO11300;

namespace Mittausdata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable()]
    public partial class MainWindow : Window
    {
        // luodaan kokoelma mittaus-olioille
        List<MittausData> mitatut;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
            txtToday.Text = DateTime.Today.ToShortDateString();
            mitatut = new List<MittausData>();
        }
        private void IniMyStuff()
        {
            // omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan uusi mittausdata olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            //lbData.Items.Add(md);
            // Lisätään mittaus-olio kokoelmaan
            mitatut.Add(md);
            ApplyChanges();
        }
        
        private void ApplyChanges()
        {
            // päivitetään UI vastaamaan kokoelman tietoja
            lbData.ItemsSource = null;
            lbData.ItemsSource = mitatut;
        }

        private void btnBrowseFiles_Click(object sender, RoutedEventArgs e)
        {
            //avataan vakio Open-dialogi jotta käyttäjä voi valita yhden tiedoston
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "D:\\H8699";
            dlg.Filter = "Dat files (*.dat)|*.dat|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            // TODO kutsu BL:n tallennusmetodia
            try
            {
                MittausData.SaveDataToFile(mitatut, txtFileName.Text);
                MessageBox.Show("Tiedot tallennettu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnShowFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                Serialisointi se = new Serialisointi();
                se.Serialisoi("data.dat", lbData.Items);
                
            }
            catch (IOException)
            {
                MessageBox.Show("asd");
            }
            */
        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            // Luetaan datat käyttäjän antamasta tiedostosta
            try
            {
                mitatut = null;
                mitatut = MittausData.ReadDataFromFile(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot luettu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnSaveToXML_Click(object sender, RoutedEventArgs e)
        {
            //serialisoidaan XML:ksi
            JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(@"D:\testi.xml", mitatut);
        }
    }
}
