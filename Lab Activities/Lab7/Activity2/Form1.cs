using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity2
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected pizza size
            string pizzaSize = comboBoxPizzaSize.SelectedItem?.ToString() ?? "No size selected";

            // Get selected toppings
            string toppings = "";
            if (checkBoxCheese.Checked) toppings += "Cheese, ";
            if (checkBoxPepperoni.Checked) toppings += "Pepperoni, ";
            if (checkBoxMushrooms.Checked) toppings += "Mushrooms, ";
            toppings = toppings.TrimEnd(',', ' '); // Remove trailing comma

            // Get the selected crust type
            string crustType = radioButtonThinCrust.Checked ? "Thin Crust" :
                               radioButtonThickCrust.Checked ? "Thick Crust" :
                               "No crust selected";

            // Display the order summary
            labelOrderSummary.Text = $"Order Summary:\n" +
                                      $"Size: {pizzaSize}\n" +
                                      $"Toppings: {(string.IsNullOrEmpty(toppings) ? "None" : toppings)}\n" +
                                      $"Crust: {crustType}";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
