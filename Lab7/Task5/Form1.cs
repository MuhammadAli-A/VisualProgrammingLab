using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
private long CalculateFactorial(int number)
        {
            long factorial = 1;
            
            // Calculate factorial
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {

 // Check if the input is a valid number
            if (int.TryParse(textBoxNumber.Text, out int number) && number >= 0)
            {
                // Calculate factorial
                long factorial = CalculateFactorial(number);

                // Display the result in the second TextBox (textBoxResult)
                textBoxResult.Text = factorial.ToString();
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid non-negative integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
   // Close the application
            this.Close();



        }
    }
}
