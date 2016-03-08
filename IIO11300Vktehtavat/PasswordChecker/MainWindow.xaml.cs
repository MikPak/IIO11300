using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PasswordChecker
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

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int score = 0;
            int upper = 0;
            int lower = 0;
            int digits = 0;
            int puncts = 0;

            string passwd = passwordBox.Password.ToString();

            upper = passwd.Count(x => Char.IsUpper(x));
            lower = passwd.Count(x => Char.IsLower(x));
            digits = passwd.Count(x => Char.IsDigit(x));
            puncts = passwd.Count(x => Char.IsPunctuation(x));

            // If string contains lowercase letters
            if (passwd.Any(x => char.IsLower(x)))
            {
                score++;
            }
            // If string contains uppercase letters
            if (passwd.Any(x => char.IsUpper(x)))
            {
                score++;
            }
            // If string contains digits
            if (passwd.Any(x => char.IsDigit(x)))
            {
                score++;
            }
            // If string contains punctuations
            if (passwd.Any(x => char.IsPunctuation(x)))
            {
                score++;
            }

            // Show password stats
            passwdLenghtLabel.Content = "Merkkejä: " + passwd.Length;
            passwdUpperLabel.Content = "Isoja kirjaimia: " + upper;
            passwdLowerLabel.Content = "Pieniä kirjaimia: " + lower;
            passwdDigitLabel.Content = "Numeroita: " + digits;
            passwdPunctuationLabel.Content = "Erikoismerkkejä: " + puncts;

            // Default
            if (passwd.Length == 0)
            {
                passwdIndicatorHolder.Background = new SolidColorBrush(Color.FromArgb(255,195,197,204)); // Harmaa
                passwdIndicator.Content = "anna salasana";
                passwdLenghtLabel.Content = "...";
                passwdUpperLabel.Content = "...";
                passwdLowerLabel.Content = "...";
                passwdDigitLabel.Content = "...";
                passwdPunctuationLabel.Content = "...";
                // Bad
            } else if (passwd.Length < 8 || score == 1)
            {
                passwdIndicatorHolder.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xcd, 99, 0)); // Oranssi
                passwdIndicator.Content = "bad";
                // Fair
            } else if (passwd.Length > 8 && passwd.Length < 13 && score == 2)
            {
                passwdIndicatorHolder.Background = new SolidColorBrush(Color.FromArgb(0xFF, 247, 255, 0)); // Keltainen
                passwdIndicator.Content = "fair";
                // Moderate
            } else if (passwd.Length > 12 && passwd.Length < 17 && score == 3)
            {
                passwdIndicatorHolder.Background = new SolidColorBrush(Color.FromArgb(0xFF, 51, 255, 51)); // Vihreä
                passwdIndicator.Content = "moderate";
                // Good
            } else if (passwd.Length >= 16 && score == 4)
            {
                passwdIndicatorHolder.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0, 153, 0)); // Vihreä
                passwdIndicator.Content = "good";
            }
        }
    }
}
