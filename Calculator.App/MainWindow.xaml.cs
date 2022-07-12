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
        public Calc calc;
        public MainWindow()
        {
            calc = new Calc();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button ?button = sender as Button;
            if (button?.Content.ToString() == "0" && InputBox.Text == "0")
            {
                return;
            }
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
            calc.Input = InputBox.Text;
            var result = calc.GetResult();
            InputBox.Text = result.ToString();
        }
        
        private void ButtonOperation_OnClick(object sender, RoutedEventArgs e)
        {
            Button ?button = sender as Button;
            
            if (!(calc.CheckOperator(InputBox.Text)))
            {
                InputBox.Text += button?.Content.ToString();
            }
            else
            {
                calc.Input = InputBox.Text;
                var i = InputBox.Text.ElementAt(InputBox.Text.Length - 1);
                //check last--- EXAMPLE : 15+ + will return nothing
                if (calc.CheckOperator(i.ToString()))
                {
                    return;
                }
                var result = calc.GetResult();
                InputBox.Text = result.ToString() + button.Content;
            }
        }
    }
}