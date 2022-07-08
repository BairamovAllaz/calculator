using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Calculator.App
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button ?button = sender as Button;
            InputBox.Text += button?.Content.ToString();
        }
        private void ButtonC_OnClick(object sender, RoutedEventArgs e)
        {
            var text = InputBox.Text;
            InputBox.Text = text.Remove(text.Length-1, 1);
        }
        private void ButtonClearAll_OnClick(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
        }
        private void ButttonEqual_OnClick(object sender, RoutedEventArgs e)
        {
            List<string> l = Calc.ParseString(InputBox.Text);
            for (int i = 0; i < l.Count; i++)
            {
                MessageBox.Show(l[i].ToString());
            }
        }
        
        
    }
}