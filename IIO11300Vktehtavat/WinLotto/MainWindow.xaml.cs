/*
* Copyright (C) JAMK/IT/Mikko Pakkanen
* This file is part of the IIO11300 course project.
* Created: 26.1.2016 Modified xx.xx.xxxx
* Authors: Mikko Pakkanen
*/

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
                    string separator = ", ";
                    DrawnNumbers.Text = string.Join(separator, numerot);
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
                MessageBox.Show(ex.Message);
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
