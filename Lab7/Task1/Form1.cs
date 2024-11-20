using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        private double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        private double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        private double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return num1 / num2;
        }



        private bool ValidateInputs(out double num1, out double num2)
        {
            bool isValid = true;

            if (!double.TryParse(textBoxNumber1.Text, out num1))
            {
                MessageBox.Show("Please enter a valid number in the first input box.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (!double.TryParse(textBoxNumber2.Text, out num2))
            {
                MessageBox.Show("Please enter a valid number in the second input box.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }



 private void button1_Click(object sender, EventArgs e)
        {
 if (ValidateInputs(out double num1, out double num2))
    {
        double result = Add(num1, num2);
        textBoxResult.Text = result.ToString();
    }
        }




        private void buttonSubtract_Click(object sender, EventArgs e)
        {
 if (ValidateInputs(out double num1, out double num2))
    {
        double result = Subtract(num1, num2);
        textBoxResult.Text = result.ToString();
    }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
if (ValidateInputs(out double num1, out double num2))
    {
        double result = Multiply(num1, num2);
        textBoxResult.Text = result.ToString();
    }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
  if (ValidateInputs(out double num1, out double num2))
    {
        double result = Divide(num1, num2);
        textBoxResult.Text = result.ToString();
    }
        }
    }
}
