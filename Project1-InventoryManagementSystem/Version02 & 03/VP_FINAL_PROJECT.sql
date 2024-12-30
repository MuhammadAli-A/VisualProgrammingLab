-- Create Database
CREATE DATABASE InventoryManagementsYstem;


-- Use the Database
USE InventoryManagementsYstem;


-- Create Admin Table
CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Pass NVARCHAR(50) NOT NULL
);

-- Insert Sample Data into Admin
INSERT INTO Admin (Username, Pass)
VALUES 
('Hassan', 'Hassan123'),
('Admin2', 'Admin2');

-- Create Categories Table
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL
);

-- Insert Sample Data into Categories
INSERT INTO Categories (CategoryName)
VALUES 
('Electronics'),
('Furniture'),
('Clothing'),
('Books');

-- Create Orders Table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100),
    Address NVARCHAR(255),
    Email NVARCHAR(100)
);

-- Insert Sample Data into Orders
INSERT INTO Orders (ProductId, ProductName, Address, Email)
VALUES 
(1, 'Laptop', '123 Main St, Cityville', 'customer1@example.com'),
(2, 'Chair', '456 Elm St, Townsville', 'customer2@example.com'),
(3, 'T-Shirt', '789 Pine St, Hamlet', 'customer3@example.com');

-- Create Products Table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
);

-- Insert Sample Data into Products
INSERT INTO Products (ProductName, Quantity, Price, CategoryId)
VALUES 
('Laptop', 10, 800.00, 1),
('Table', 5, 150.00, 2),
('T-Shirt', 50, 20.00, 3),
('Novel', 30, 12.99, 4);

-- Create Suppliers Table
CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(50) NOT NULL
);

-- Insert Sample Data into Suppliers
INSERT INTO Suppliers (SupplierName, Contact)
VALUES 
('Tech Supplies Co.', '123-456-7890'),
('Home Furnishings Inc.', '987-654-3210'),
('Apparel World', '456-789-1234'),
('Book Distributors Ltd.', '321-654-9870');

-- Create Users Table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClientName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Date DATE NOT NULL
);

-- Insert Sample Data into Users
INSERT INTO Users (ClientName, Phone, Date)
VALUES 
('John Doe', '555-123-4567', '2024-12-01'),
('Jane Smith', '555-987-6543', '2024-12-02'),
('Alice Johnson', '555-456-7891', '2024-12-03'),
('Bob Brown', '555-789-1234', '2024-12-04');

-- Verify the Data
SELECT * FROM Admin;
SELECT * FROM Categories;
SELECT * FROM Orders;
SELECT * FROM Products;
SELECT * FROM Suppliers;
SELECT * FROM Users;
