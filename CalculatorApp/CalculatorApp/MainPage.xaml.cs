using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        private double currentState;
        private string mathOperator;
        private double firstNumber;
        private double secondNumber;
    
        public MainPage()
        {
            InitializeComponent();
            OnClear_Clicked(null, EventArgs.Empty);
        }


        private void OnSelectNumber_Clicked(object sender, EventArgs e)
        {
            if (resultText.Text == "0") resultText.Text = "";

            if (!string.IsNullOrEmpty(mathOperator))
            {
                var newNumber = secondNumber + ((Button) sender).Text;
                secondNumber = double.Parse(newNumber);
            }
            
            resultText.Text += ((Button)sender).Text;
        }

        private void OnSelectOperator_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mathOperator)) return;
            
            firstNumber = double.Parse(resultText.Text);
            currentState = firstNumber;
            mathOperator = ((Button) sender).Text;
            resultText.Text += mathOperator;
        }

        private void OnClear_Clicked(object sender, EventArgs e)
        {
            currentState = 0;
            mathOperator = "";
            firstNumber = 0;
            secondNumber = 0;
        }

        private void OnCalculate_Clicked(object sender, EventArgs e)
        {
            switch (mathOperator.ToLower())
            {
                case "x":
                    currentState = firstNumber * secondNumber;
                    break;
                
                case "/":
                    currentState = firstNumber / secondNumber;
                    break;
                
                case "+":
                    currentState = firstNumber + secondNumber;
                    break;
                
                case "-":
                    currentState = firstNumber - secondNumber;
                    break;
            }

            resultText.Text = currentState.ToString();
            
            OnClear_Clicked(null, EventArgs.Empty);
        }

        private void OnNextPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}
