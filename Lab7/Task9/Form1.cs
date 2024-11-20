using System;
using System.Windows.Forms;

namespace Task9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for TextChanged event of the TextBox
        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            // Calculate the number of characters left
            int remainingCharacters = 160 - textBoxInput.Text.Length;

            // Update the label to show the remaining characters
            labelCharacterCount.Text = $"Characters left: {remainingCharacters}";
        }
    }
}
