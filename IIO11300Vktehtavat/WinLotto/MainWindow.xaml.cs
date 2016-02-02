/*
* Copyright (C) JAMK/IT/Mikko Pakkanen
* This file is part of the IIO11300 course project.
* Created: 26.1.2016 Modified xx.xx.xxxx
* Authors: Mikko Pakkanen
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Forms;

namespace WinLotto
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

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DropDownMenu.Text == "Suomi")
                {
                    //luodaan Lotto-luokasta olio
                    Lotto lotto = new Lotto();
                    int[] numerot = new int[6];
                    numerot = Lotto.ArvoSuomiLotto(1);

                    //tulos käyttäjälle
                    string separator = " ";
                    DrawnNumbers.AppendText(string.Join(separator, numerot) + ";\n");
                }
                else if (DropDownMenu.Text == "VikingLotto")
                {
                    // kutsutaan lotto-luokan metodia..
                }
                else if (DropDownMenu.Text == "Eurojackpot")
                {
                    // kutsutaan lotto-luokan metodia..
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawnNumbers.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog savefile = new Microsoft.Win32.SaveFileDialog();
            savefile.FileName = "Lottorivit";
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            Nullable<bool> result = savefile.ShowDialog();
            if (result == true)
            {
                File.WriteAllText(savefile.FileName, DrawnNumbers.Text); 
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openfile = new Microsoft.Win32.OpenFileDialog();
            openfile.FileName = "Lottorivit";
            openfile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            Nullable<bool> result = openfile.ShowDialog();
            if (result == true)
            {
                string contents = File.ReadAllText(openfile.FileName);
                DrawnNumbers.Text = contents;
            }
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            if (correctNumbers.Text != "")
            {
                Microsoft.Win32.OpenFileDialog openfile = new Microsoft.Win32.OpenFileDialog();
                openfile.FileName = "Lottorivit";
                openfile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                Nullable<bool> result = openfile.ShowDialog();
                if (result == true)
                {
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(openfile.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        int l = line.IndexOf(";");
                        if (l > 0)
                        {
                            /*
                            for (int i = 0; i < l; i++)
                            {
                                string str = line.Substring(i, line.IndexOf(" ")).Trim();
                                System.Windows.MessageBox.Show(str);
                            }
                             */
                        }
                    }
                }
            }
        }

        private void correctNumbers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
