/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 17.1.2016
* Authors: Mikko Pakkanen ,Esa Salmikangas
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

namespace Tehtava1
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                double width, height, karmi, areaWindow, karmiPerimeter, karmiArea;

                width = System.Convert.ToDouble(txtWidht.Text); // Convert string to double
                height = System.Convert.ToDouble(txtHeight.Text);
                karmi = System.Convert.ToDouble(txtKarmiWidth.Text);

                areaWindow = BusinessLogicWindow.CalculateArea(width, height); // Calculate area of the window
                txtIkkunaPintaAla.Text = System.Convert.ToString(areaWindow); // Set value to textbox

                karmiPerimeter = BusinessLogicWindow.CalculatePerimeter(width, height, karmi); // Calculate perimeter
                txtKarmiPiiri.Text = System.Convert.ToString(karmiPerimeter); // Set value to textbox

                karmiArea = BusinessLogicWindow.CalculatePerimeterArea(width, height, karmi); // Calculate perimeter
                txtKarmiPintaAla.Text = System.Convert.ToString(karmiArea); // Set value to textbox
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      //käynnissä olevan sovelluksen sulkeminen
      Application.Current.Shutdown();
    }
  }


}
