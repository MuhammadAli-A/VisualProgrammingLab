using System;
using System.Windows.Forms;

namespace Task7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Initialize the label with the current date and time in the desired format
            labelClock.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy" + Environment.NewLine + "hh:mm:ss tt");
        }

        // Event handler for Timer Tick
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current date and time in the desired format
            labelClock.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy" + Environment.NewLine + "hh:mm:ss tt");
        }

        // Additional Form Load logic (if needed)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: Any additional initialization can go here
        }
    }
}
