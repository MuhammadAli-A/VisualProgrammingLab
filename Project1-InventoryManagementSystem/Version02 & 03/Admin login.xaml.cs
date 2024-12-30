using System;
using System.Data.SqlClient;
using System.Windows;

namespace VP_2
{
    public partial class Admin_login : Window
    {
        public Admin_login()
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
                Main_menu menu = new Main_menu();
                menu.Show();

                this.Close(); // Close the current login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}


