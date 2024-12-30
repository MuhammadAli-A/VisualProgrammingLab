using System;
using System.Data.SqlClient;
using System.Windows;

namespace VP_2
{
    public partial class User_login : Window
    {
        public User_login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Hard-coded credentials
            const string validUsername = "Hassan";
            const string validPassword = "Hassan123";

            if (username == validUsername && password == validPassword)
            {
                Menu_user window = new Menu_user();
                window.Show();

                // Optionally, you can show a success message
                // MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close(); // Close the current login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  // Close the window
        }

        private void usernameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
