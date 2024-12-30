using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VP_2
{
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
            LoadUserData();  // Call the method to load data when the page is initialized
        }

        // Method to load user data from the database
        private void LoadUserData()
        {
            try
            {
                // Get the connection string from app.config
                string connectionString = ConfigurationManager.ConnectionStrings["InventoryManagementsYstem"].ConnectionString;
                string query = "SELECT Id, ClientName, Phone, Date FROM Users"; // SQL query to fetch user data

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind data to the DataGrid
                    UserDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the Exit button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the current page and return to the previous page
            this.NavigationService.GoBack();
        }
    }
}
