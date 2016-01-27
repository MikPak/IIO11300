﻿/*
* Copyright (C) JAMK/IT/Mikko Pakkanen
* This file is part of the IIO11300 course project.
* Created: 27.1.2016 Modified xx.xx.xxxx
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
using JAMK.IT.IIO11300;

namespace Mittausdata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
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
            lbData.Items.Add(md);
        }
    }
}