﻿using System;
using System.Data.SqlClient;
using System.Windows;

namespace VP_2
{
    public partial class AdminBuyProductsWindow : Window
    {
        public AdminBuyProductsWindow()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            string connectionString = "Server=DESKTOP-8IHO1V4\\SQLEXPRESS;Database=InventoryManagementsYstem;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = "SELECT SupplierId, SupplierName FROM Suppliers";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SupplierComboBox.Items.Add(new { SupplierId = reader.GetInt32(0), SupplierName = reader.GetString(1) });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (!int.TryParse(ProductIdTextBox.Text, out int productId))
            {
                MessageBox.Show("Invalid Product ID. Please enter a valid numeric Product ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid Quantity. Please enter a positive number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (SupplierComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a supplier.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedSupplier = (dynamic)SupplierComboBox.SelectedItem;
            int supplierId = selectedSupplier.SupplierId;
            string supplierName = selectedSupplier.SupplierName;

            // Database connection string
            string connectionString = "Server=DESKTOP-8IHO1V4\\SQLEXPRESS;Database=InventoryManagementsYstem;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get product price and category from the Products table
                    string getProductInfoQuery = "SELECT Price, CategoryId, ProductName FROM Products WHERE ProductId = @ProductId";
                    SqlCommand getProductInfoCommand = new SqlCommand(getProductInfoQuery, connection);
                    getProductInfoCommand.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataReader productReader = getProductInfoCommand.ExecuteReader();

                    if (!productReader.Read())
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    decimal productPrice = productReader.GetDecimal(0);  // Now defined here after retrieving from the database
                    int categoryId = productReader.GetInt32(1);
                    string productName = productReader.GetString(2);

                    productReader.Close();

                    decimal totalCost = quantity * productPrice; // Now we can calculate total cost
                    TotalCostTextBox.Text = totalCost.ToString("0.##"); // Display total cost with 2 decimal places

                    // Generate a new PurchaseOrderId
                    string getMaxPurchaseOrderIdQuery = "SELECT MAX(PurchaseOrderId) FROM PurchaseOrders";
                    SqlCommand getMaxPurchaseOrderIdCommand = new SqlCommand(getMaxPurchaseOrderIdQuery, connection);
                    object result = getMaxPurchaseOrderIdCommand.ExecuteScalar();
                    int newPurchaseOrderId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;

                    // Insert the purchase order
                    string insertPurchaseOrderQuery = "INSERT INTO PurchaseOrders (PurchaseOrderId, ProductId, ProductName, SupplierId, SupplierName, Quantity, TotalCost, OrderDate) VALUES (@PurchaseOrderId, @ProductId, @ProductName, @SupplierId, @SupplierName, @Quantity, @TotalCost, @OrderDate)";
                    SqlCommand insertPurchaseOrderCommand = new SqlCommand(insertPurchaseOrderQuery, connection);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@PurchaseOrderId", newPurchaseOrderId);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@ProductId", productId);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@ProductName", productName);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@SupplierId", supplierId);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@SupplierName", supplierName);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@TotalCost", totalCost);
                    insertPurchaseOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                    insertPurchaseOrderCommand.ExecuteNonQuery();

                    // Check if the product exists in the Products table and update it
                    string checkProductExistsQuery = "SELECT COUNT(*) FROM Products WHERE ProductId = @ProductId";
                    SqlCommand checkProductExistsCommand = new SqlCommand(checkProductExistsQuery, connection);
                    checkProductExistsCommand.Parameters.AddWithValue("@ProductId", productId);
                    int productCount = (int)checkProductExistsCommand.ExecuteScalar();

                    if (productCount == 0)
                    {
                        // Insert the new product if it doesn't exist
                        string insertProductQuery = "INSERT INTO Products (ProductId, ProductName, Quantity, Price, CategoryId) VALUES (@ProductId, @ProductName, @Quantity, @Price, @CategoryId)";
                        SqlCommand insertProductCommand = new SqlCommand(insertProductQuery, connection);
                        insertProductCommand.Parameters.AddWithValue("@ProductId", productId);
                        insertProductCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertProductCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertProductCommand.Parameters.AddWithValue("@Price", productPrice);
                        insertProductCommand.Parameters.AddWithValue("@CategoryId", categoryId);

                        insertProductCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Update the existing product inventory
                        string updateProductQuery = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE ProductId = @ProductId";
                        SqlCommand updateProductCommand = new SqlCommand(updateProductQuery, connection);
                        updateProductCommand.Parameters.AddWithValue("@Quantity", quantity);
                        updateProductCommand.Parameters.AddWithValue("@ProductId", productId);

                        updateProductCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Purchase completed successfully! Purchase Order ID is {newPurchaseOrderId}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing purchase: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}