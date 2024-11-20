using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
// Check if the input is a valid number
            if (double.TryParse(textBoxFahrenheit.Text, out double fahrenheit))
            {
                // Perform the conversion
                double celsius = ConvertFahrenheitToCelsius(fahrenheit);

                // Display the result in the Celsius text box
                textBoxCelsius.Text = celsius.ToString("F2"); // Format to 2 decimal places
            }
            else
            {
                // Show an error message if the input is not valid
                MessageBox.Show("Please enter a valid number for Fahrenheit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    
                    
                 
            }






        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
 // Close the application
            this.Close();
        }
    }
}
