using Calculator.Utility;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;

        private double result;
        
        private SelectedOperator selectedOperator;
        
        public MainWindow()
        {
            InitializeComponent();

            //Evento para o botão AC.
            acButton.Click += AcButton_Click;

            //Evento para o botão Negativo.
            negativeButton.Click += NegativeButton_Click;

            //Evento para o botão de Porcentagem.
            percentageButton.Click += PercentageButton_Click;

            //Evento para o botão de Igualdade.
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Sustraction:
                        result = SimpleMath.Sustraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);

                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }

                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * (-1);
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            //Zera o visor.
            resultLabel.Content = "0";

            //Zera o resultado.
            result = 0;

            //Zera o último número.
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;

            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;

            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;

            if (sender == minusButton)
                selectedOperator = SelectedOperator.Sustraction;
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains(","))
            {
                resultLabel.Content = $"{resultLabel.Content},";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;

            if (sender == oneButton)
                selectedValue = 1;

            if (sender == twoButton)
                selectedValue = 2;

            if (sender == threeButton)
                selectedValue = 3;

            if (sender == fourButton)
                selectedValue = 4;

            if (sender == fiveButton)
                selectedValue = 5;

            if (sender == sixButton)
                selectedValue = 6;

            if (sender == sevenButton)
                selectedValue = 7;

            if (sender == eightButton)
                selectedValue = 8;

            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }
}