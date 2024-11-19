using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // Display a personalized greeting message
                label3.Text = $"Hello, {textBox1.Text}! Welcome!";
            }
            else
            {
                // If no name is entered, ask the user to enter their name
                label3.Text = "Please enter your name.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
