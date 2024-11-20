using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
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
        private int CalculateSquare(int number)
        {
            return number * number;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
  listBoxResults.Items.Clear(); // Clear previous results if any

            for (int i = 1; i <= 10; i++)
            {
                int square = CalculateSquare(i); // Call the method
                listBoxResults.Items.Add($"Number:{i}  Square:{square}");
            }

        }
    }
}
