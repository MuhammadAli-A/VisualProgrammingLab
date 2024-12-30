using System;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class Menu_user : Window
    {
        public Menu_user()
        {
            InitializeComponent();
        }

        // Event handler for the "Show User" button
        private void ShowUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the UserListPage when the button is clicked
            ContentFrame.Navigate(new UserListPage());
        }

        // Event handler for the "Place Order" button
        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a new window to place an order
            PlaceOrderWindow placeOrderWindow = new PlaceOrderWindow();
            placeOrderWindow.ShowDialog();
        }

        // Event handler for the "Exit" button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            this.Close();
        }

        private void ContentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            // Handle any actions on navigation (optional)
        }
    }
}
