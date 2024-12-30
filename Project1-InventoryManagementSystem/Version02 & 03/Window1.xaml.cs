using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;

namespace VP_2
{
    public partial class Window1 : Window
    {
        private string connectionString;

        public ObservableCollection<Product> Products { get; set; }

        public Window1()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryManagementSystem"].ConnectionString;
            Products = new ObservableCollection<Product>();
            productDataGrid.ItemsSource = Products;
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products.Clear();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductId, ProductName, Quantity, Price, CategoryId FROM Products";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Products.Add(new Product
                        {
                            ProductId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            ProductName = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1),
                            Quantity = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            Price = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                            CategoryId = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new ProductInputDialog();
            var result = inputDialog.ShowDialog();

            if (result == true)
            {
                var newProduct = new Product
                {
                    ProductName = inputDialog.ProductName,
                    Quantity = inputDialog.Quantity,
                    Price = inputDialog.Price,
                    CategoryId = inputDialog.CategoryId
                };

                using (var connection = new SqlConnection(connectionString))
                {
                    // Check if the CategoryId exists
                    string checkCategoryQuery = "SELECT COUNT(*) FROM Categories WHERE CategoryId = @CategoryId";
                    SqlCommand checkCommand = new SqlCommand(checkCategoryQuery, connection);
                    checkCommand.Parameters.AddWithValue("@CategoryId", newProduct.CategoryId);

                    try
                    {
                        connection.Open();
                        int categoryExists = (int)checkCommand.ExecuteScalar();

                        if (categoryExists == 0)
                        {
                            MessageBox.Show("The provided CategoryId does not exist. Please select a valid CategoryId.");
                            return;
                        }

                        // Proceed with product insertion
                        string insertQuery = "INSERT INTO Products (ProductName, Quantity, Price, CategoryId) VALUES (@ProductName, @Quantity, @Price, @CategoryId)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@ProductName", newProduct.ProductName);
                        insertCommand.Parameters.AddWithValue("@Quantity", newProduct.Quantity);
                        insertCommand.Parameters.AddWithValue("@Price", newProduct.Price);
                        insertCommand.Parameters.AddWithValue("@CategoryId", newProduct.CategoryId);

                        insertCommand.ExecuteNonQuery();
                        LoadProducts();
                        MessageBox.Show("Product added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                var inputDialog = new ProductInputDialog
                {
                    ProductId = selectedProduct.ProductId,
                    ProductNameTextBox = { Text = selectedProduct.ProductName },
                    QuantityTextBox = { Text = selectedProduct.Quantity.ToString() },
                    PriceTextBox = { Text = selectedProduct.Price.ToString() },
                    CategoryIdTextBox = { Text = selectedProduct.CategoryId.ToString() }
                };

                if (inputDialog.ShowDialog() == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Products SET ProductName = @ProductName, Quantity = @Quantity, Price = @Price, CategoryId = @CategoryId WHERE ProductId = @ProductId";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ProductName", inputDialog.ProductNameTextBox.Text);
                        command.Parameters.AddWithValue("@Quantity", int.Parse(inputDialog.QuantityTextBox.Text));
                        command.Parameters.AddWithValue("@Price", decimal.Parse(inputDialog.PriceTextBox.Text));
                        command.Parameters.AddWithValue("@CategoryId", int.Parse(inputDialog.CategoryIdTextBox.Text));
                        command.Parameters.AddWithValue("@ProductId", inputDialog.ProductId);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            LoadProducts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No product selected to update.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = productDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Products WHERE ProductId = @ProductId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", selectedProduct.ProductId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Products.Remove(selectedProduct);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("No product selected to delete.");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var input = Prompt.ShowDialog("Enter Product Name to Search:", "Search Product");
            if (!string.IsNullOrEmpty(input))
            {
                Products.Clear();
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ProductId, ProductName, Quantity, Price, CategoryId FROM Products WHERE ProductName LIKE @ProductName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", "%" + input + "%");

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Products.Add(new Product
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetDecimal(3),
                                CategoryId = reader.GetInt32(4)
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Search input is empty.");
            }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
