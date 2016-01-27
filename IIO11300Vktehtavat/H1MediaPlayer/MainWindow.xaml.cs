using Microsoft.Win32;
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

namespace H1MediaPlayer
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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            LoadMediaFile();
            mediaElement.Play();
            // Muutetaan nappuloiden tilaa
            btnPause.IsEnabled = true;
            btnStop.IsEnabled = true;
            btnPlay.IsEnabled = false;
            ChangeButtonsState();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void LoadMediaFile()
        {
            try
            {
                // Ladataan käyttäjän antama mediatiedosto
                //string filu = @"D:\H8699\CoffeeMaker.mp4";
                string filu = txtFileName.Text;
                if (System.IO.File.Exists(filu))
                {
                    mediaElement.Source = new Uri(filu);
                    mediaElement.Play();
                } else
                {
                    MessageBox.Show("Tiedostoa " + filu + " ei löydy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            //avataan vakio Open-dialogi jotta käyttäjä voi valita yhden tiedoston
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "D:\\H8699";
            dlg.Filter = "Rock files (*.mp3)|*.mp3|Media files (*.wmv)|*.wmv|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            
            if(result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private void ChangeButtonsState()
        {
            btnPause.IsEnabled = !btnPause.IsEnabled;
            btnStop.IsEnabled = !btnStop.IsEnabled;
            btnPlay.IsEnabled = !btnPlay.IsEnabled;
        }
    }
}
