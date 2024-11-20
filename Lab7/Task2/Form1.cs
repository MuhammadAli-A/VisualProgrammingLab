using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task2
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = string.Empty;
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Assign digit handlers
            button0.Click += DigitButton_Click;
            button1.Click += DigitButton_Click;
            button2.Click += DigitButton_Click;
            button3.Click += DigitButton_Click;
            button4.Click += DigitButton_Click;
            button5.Click += DigitButton_Click;
            button6.Click += DigitButton_Click;
            button7.Click += DigitButton_Click;
            button8.Click += DigitButton_Click;
            button9.Click += DigitButton_Click;

            // Assign operator handlers
            buttonAdd.Click += OperatorButton_Click;
            buttonSubtract.Click += OperatorButton_Click;
            buttonMultiply.Click += OperatorButton_Click;
            buttonDivide.Click += OperatorButton_Click;

            // Assign equals and clear handlers
            buttonEquals.Click += buttonEquals_Click;
            buttonClear.Click += buttonClear_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }
        // Common handler for digit buttons
        private void DigitButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (isOperationPerformed)
            {
                textBoxDisplay.Text = string.Empty; // Clear display after an operator
                isOperationPerformed = false;
            }

            textBoxDisplay.Text += button.Text; // Append the digit
        }

        // Common handler for operator buttons
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (!double.TryParse(textBoxDisplay.Text, out firstNumber))
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
                return;
            }

            operation = button.Text; // Store the operator
            isOperationPerformed = true;
        }

        // Equals button handler
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBoxDisplay.Text, out secondNumber))
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
                return;
            }

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.");
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
                default:
                    MessageBox.Show("Please select an operator.");
                    return;
            }

            textBoxDisplay.Text = result.ToString();
            firstNumber = result; // Store result for continued calculations
            isOperationPerformed = true;
        }

        // Clear button handler
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = string.Empty;
            firstNumber = 0;
            secondNumber = 0;
            operation = string.Empty;
            isOperationPerformed = false;
        }
    }
}
