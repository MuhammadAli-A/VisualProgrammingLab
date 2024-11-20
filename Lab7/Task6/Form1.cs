using System;
using System.Windows.Forms;

namespace Task6
{
    public partial class Form1 : Form
    {
        private int remainingTime; // Variable to store the remaining time in seconds

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000; // Set the timer interval to 1 second (1000 ms)
            timer.Tick += TimerCountdown_Tick; // Event handler for Timer tick
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any initialization code you want when the form loads
        }



        // Event handler for the timer's Tick event
        private void TimerCountdown_Tick(object sender, EventArgs e)
        {
            // Decrease the remaining time by 1 second
            remainingTime--;

            // Update the label with the new remaining time
            labelCountdown.Text = remainingTime.ToString();

            // If the countdown reaches zero
            if (remainingTime == 0)
            {
                // Stop the timer
                timer.Stop();

                // Show a message when the time is over
                MessageBox.Show("Time's up!", "Countdown Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for the "Start" button click
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Check if the input is a valid number
            if (int.TryParse(textBoxTime.Text, out remainingTime) && remainingTime > 0)
            {
                // Display the countdown time in the label
                labelCountdown.Text = remainingTime.ToString();

                // Start the countdown timer
                timer.Start();
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid number greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional: Event handler for the "Exit" button if you want to close the application
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
