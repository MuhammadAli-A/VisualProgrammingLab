using System;
using System.Collections.Generic;
using System.Windows;

namespace VP_2
{
    public partial class PlaceOrderWindow : Window
    {
        private List<Product> electronics = new List<Product>();
        private List<Product> furniture = new List<Product>();

        // Declare a variable to hold the order ID
        private int orderId;

        public PlaceOrderWindow()
        {
            InitializeComponent();

            // Adding dummy data for Electronics
            electronics.Add(new Product { ProductId = 1, ProductName = "Laptop", Quantity = 10, Price = 999.99m });
            electronics.Add(new Product { ProductId = 2, ProductName = "Smartphone", Quantity = 20, Price = 499.99m });
            electronics.Add(new Product { ProductId = 3, ProductName = "Tablet", Quantity = 15, Price = 299.99m });
            electronics.Add(new Product { ProductId = 4, ProductName = "Smartwatch", Quantity = 30, Price = 199.99m });
            electronics.Add(new Product { ProductId = 5, ProductName = "Headphones", Quantity = 25, Price = 89.99m });

            // Adding dummy data for Furniture
            furniture.Add(new Product { ProductId = 6, ProductName = "Sofa", Quantity = 5, Price = 599.99m });
            furniture.Add(new Product { ProductId = 7, ProductName = "Dining Table", Quantity = 10, Price = 399.99m });
            furniture.Add(new Product { ProductId = 8, ProductName = "Office Chair", Quantity = 20, Price = 149.99m });
            furniture.Add(new Product { ProductId = 9, ProductName = "Bookshelf", Quantity = 15, Price = 79.99m });
            furniture.Add(new Product { ProductId = 10, ProductName = "Coffee Table", Quantity = 25, Price = 49.99m });

            // Bind data to ListViews
            ElectronicsListView.ItemsSource = electronics;
            FurnitureListView.ItemsSource = furniture;
        }

        private void SubmitOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if address and email fields are filled
            if (string.IsNullOrEmpty(AddressTextBox.Text) || string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Please fill in both the address and email fields before submitting the order.");
                return;
            }

            // Generate a random order ID and store it in the orderId variable
            Random rand = new Random();
            orderId = rand.Next(1000, 9999);

            // Show the success message with the generated order ID
            MessageBox.Show($"Order Submitted successfully!\nYour Order ID is: {orderId}");
        }

        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if an order ID exists (i.e., user has submitted the order first)
            if (orderId == 0)
            {
                MessageBox.Show("Please submit an order first.");
                return;
            }

            // Show the message with the generated order ID (the same ID as for submission)
            MessageBox.Show($"Order Cancelled!\nYour Order ID is: {orderId}");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
