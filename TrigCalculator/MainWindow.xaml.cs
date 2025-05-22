using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace TrigCalculator
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

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Execute(SinInputTextBox, SinOutputTextBox, input => Math.Sin(DegreesToRadians(input)));
            Execute(CosInputTextBox, CosOutputTextBox, input => Math.Cos(DegreesToRadians(input)));
            Execute(TanInputTextBox, TanOutputTextBox, input => Math.Tan(DegreesToRadians(input)));

            Execute(AsinInputTextBox, AsinOutputTextBox, input => RadiansToDegrees(Math.Asin(input)), "\u00BA");
            Execute(AcosInputTextBox, AcosOutputTextBox, input => RadiansToDegrees(Math.Acos(input)), "\u00BA");
            Execute(AtanInputTextBox, AtanOutputTextBox, input => RadiansToDegrees(Math.Atan(input)), "\u00BA");

            Execute(DegreesToRadiansInputTextBox, DegreesToRadiansOutputTextBox, DegreesToRadians);
            Execute(RadiansToDegreesInputTextBox, RadiansToDegreesnOutputTextBox, RadiansToDegrees);
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SinInputTextBox.Clear();
            SinOutputTextBox.Clear();
            CosInputTextBox.Clear();
            CosOutputTextBox.Clear();
            TanInputTextBox.Clear();
            TanOutputTextBox.Clear();
            AsinInputTextBox.Clear();
            AsinOutputTextBox.Clear();
            AcosInputTextBox.Clear();
            AcosOutputTextBox.Clear();
            AtanInputTextBox.Clear();
            AtanOutputTextBox.Clear();
            DegreesToRadiansInputTextBox.Clear();
            DegreesToRadiansOutputTextBox.Clear();
            RadiansToDegreesInputTextBox.Clear();
            RadiansToDegreesnOutputTextBox.Clear();
        }

        private static double DegreesToRadians(double degrees) 
        {
            return degrees / 180 * Math.PI;
        }
        private static double RadiansToDegrees(double radians) 
        {
            return radians / Math.PI * 180;
        }

        private static void Execute(TextBox input, TextBox output, Func<double, double> function, string? suffix = null) 
        {
            if (TryParse(input.Text, out double parsedValue)) 
            {
                output.Text = $"{Math.Round(function(parsedValue), 2)}{suffix}";
            }
        }
        private static bool TryParse(string? input, out double output) 
        {
            if (input is null) 
            {
                output = 0;
                return false;
            }

            return double.TryParse(input.Replace(",", "."), CultureInfo.InvariantCulture, out output);
        }
    }
}
