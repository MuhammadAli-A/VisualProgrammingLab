using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace VP_2
{
    public partial class Category_Management : Window
    {
        private string connectionString;

        public Category_Management()
        {
            InitializeComponent();
            // Retrieve the connection string from App.config
            connectionString = ConfigurationManager.ConnectionStrings["InventoryManagementsYstem"].ConnectionString;
            LoadCategoryData();
        }

        private void LoadCategoryData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Categories", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    categoryDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryName = Prompt_2.ShowDialog("Enter Category Name:", "Add Category");

                if (!string.IsNullOrEmpty(categoryName))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Remove CategoryID from the insert statement
                        string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Category added successfully.");
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show("Category Name is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }



        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryId = Prompt_2.ShowDialog("Enter Category ID to delete:", "Delete Category");

                if (!string.IsNullOrEmpty(categoryId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", int.Parse(categoryId));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Category deleted successfully.");
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show("Category ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
        }

        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryId = Prompt_2.ShowDialog("Enter Category ID to update:", "Update Category");

                if (!string.IsNullOrEmpty(categoryId))
                {
                    string newCategoryName = Prompt_2.ShowDialog("Enter new Category Name:", "Update Category");

                    if (!string.IsNullOrEmpty(newCategoryName))
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@CategoryName", newCategoryName);
                                cmd.Parameters.AddWithValue("@CategoryID", int.Parse(categoryId));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Category updated successfully.");
                        LoadCategoryData();
                    }
                    else
                    {
                        MessageBox.Show("Category Name is required.");
                    }
                }
                else
                {
                    MessageBox.Show("Category ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQuery = Prompt_2.ShowDialog("Enter Category Name or ID to search:", "Search Category");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Categories WHERE CategoryName LIKE @SearchQuery OR CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                        if (int.TryParse(searchQuery, out int categoryId))
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CategoryID", DBNull.Value);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        categoryDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }

        private void categoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle grid selection changes if necessary
        }
    }

    public static class Prompt_2
    {
        public static string ShowDialog(string text, string caption, string defaultText = "")
        {
            Window prompt = new Window
            {
                Width = 300,
                Height = 150,
                Title = caption,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            StackPanel stackPanel = new StackPanel { Margin = new Thickness(10) };
            prompt.Content = stackPanel;

            Label textLabel = new Label { Content = text };
            stackPanel.Children.Add(textLabel);

            TextBox inputBox = new TextBox { Text = defaultText };
            stackPanel.Children.Add(inputBox);

            Button confirmation = new Button { Content = "OK", Width = 70, IsDefault = true };
            confirmation.Click += (sender, e) => prompt.DialogResult = true;
            stackPanel.Children.Add(confirmation);

            return prompt.ShowDialog() == true ? inputBox.Text : null;
        }
    }
}
