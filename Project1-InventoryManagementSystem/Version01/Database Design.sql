-- Step 1: Create the Database
CREATE DATABASE InventoryManagement;

-- Step 2: Use the Database
USE InventoryManagement;

-- Step 3: Create Tables
-- Table: Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    SKU NVARCHAR(50) UNIQUE NOT NULL,
    Category NVARCHAR(50) NULL,
    Quantity INT DEFAULT 0,
    UnitPrice DECIMAL(10, 2) NULL,
    Barcode NVARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);

-- Table: Suppliers
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100) NULL,
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL,
    Address NVARCHAR(255) NULL
);

-- Table: PurchaseOrders
CREATE TABLE PurchaseOrders (
    PurchaseOrderID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Table: PurchaseOrderDetails
CREATE TABLE PurchaseOrderDetails (
    PODetailID INT PRIMARY KEY IDENTITY(1,1),
    PurchaseOrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PurchaseOrderID) REFERENCES PurchaseOrders(PurchaseOrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Table: SalesOrders
CREATE TABLE SalesOrders (
    SalesOrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Shipped', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL
);

-- Table: SalesOrderDetails
CREATE TABLE SalesOrderDetails (
    SODetailID INT PRIMARY KEY IDENTITY(1,1),
    SalesOrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (SalesOrderID) REFERENCES SalesOrders(SalesOrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Table: StockMovements
CREATE TABLE StockMovements (
    MovementID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    MovementType NVARCHAR(20) CHECK (MovementType IN ('IN', 'OUT', 'ADJUSTMENT')),
    Quantity INT NOT NULL,
    MovementDate DATETIME DEFAULT GETDATE(),
    Description NVARCHAR(255) NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Table: Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Manager', 'Staff')),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Table: AuditLogs
CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Action NVARCHAR(100) NOT NULL,
    TableAffected NVARCHAR(50) NULL,
    ActionTime DATETIME DEFAULT GETDATE(),
    Description NVARCHAR(255) NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Table: Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) UNIQUE NOT NULL,
    Description NVARCHAR(255) NULL
);
-- Insert values into Categories
INSERT INTO Categories (CategoryName, Description)
VALUES 
('Electronics', 'Electronic items'),
('Furniture', 'Home and office furniture'),
('Clothing', 'Apparel and accessories'),
('Books', 'Educational and recreational books'),
('Food', 'Groceries and perishable items');

-- Insert values into Products
INSERT INTO Products (Name, SKU, Category, Quantity, UnitPrice, Barcode)
VALUES 
('Smartphone', 'ELEC-001', 'Electronics', 50, 699.99, '123456789012'),
('Office Chair', 'FURN-001', 'Furniture', 20, 89.99, '223456789012'),
('T-Shirt', 'CLOT-001', 'Clothing', 100, 14.99, '323456789012'),
('Cookbook', 'BOOK-001', 'Books', 15, 24.99, '423456789012'),
('Chocolate Bar', 'FOOD-001', 'Food', 200, 1.99, '523456789012');

-- Insert values into Suppliers
INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address)
VALUES 
('Tech Supply Co.', 'Ali', '123-456-7890', 'Ali@techsupply.com', '123 Tech St.'),
('Furniture Hub', 'Azhar', '234-567-8901', 'Azhar@furniturehub.com', '456 Home Ave.'),
('Fashion World', 'Hassan', '345-678-9012', 'Hassan@fashionworld.com', '789 Style Blvd.'),
('Book Haven', 'Aslam', '456-789-0123', 'Aslam@bookhaven.com', '321 Reading Ln.'),
('Grocery Mart', 'Raheel', '567-890-1234', 'Raheel@grocerymart.com', '654 Food Ct.');

-- Insert values into Users
INSERT INTO Users (Username, PasswordHash, Role)
VALUES 
('admin', 'hashed_password_1', 'Admin'),
('manager1', 'hashed_password_2', 'Manager'),
('staff1', 'hashed_password_3', 'Staff'),
('staff2', 'hashed_password_4', 'Staff'),
('manager2', 'hashed_password_5', 'Manager');

-- Insert values into PurchaseOrders
INSERT INTO PurchaseOrders (SupplierID, OrderDate, Status, TotalAmount)
VALUES 
(1, GETDATE(), 'Pending', 3500.00),
(2, GETDATE(), 'Completed', 1800.50),
(3, GETDATE(), 'Pending', 750.00),
(4, GETDATE(), 'Cancelled', NULL),
(5, GETDATE(), 'Completed', 120.75);

-- Insert values into PurchaseOrderDetails
INSERT INTO PurchaseOrderDetails (PurchaseOrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 10, 699.99),
(1, 2, 15, 89.99),
(2, 3, 50, 14.99),
(3, 4, 10, 24.99),
(5, 5, 100, 1.99);

-- Insert values into SalesOrders
INSERT INTO SalesOrders (CustomerName, OrderDate, Status, TotalAmount)
VALUES 
('Ali Customer', GETDATE(), 'Pending', 1500.00),
('Azhar Customer', GETDATE(), 'Shipped', 200.00),
('Hassan Buyer', GETDATE(), 'Cancelled', NULL),
('Aslam Shopper', GETDATE(), 'Shipped', 750.00),
('Raheel Purchaser', GETDATE(), 'Pending', 89.99);

-- Insert values into SalesOrderDetails
INSERT INTO SalesOrderDetails (SalesOrderID, ProductID, Quantity, UnitPrice)
VALUES 
(1, 1, 2, 699.99),
(2, 2, 1, 89.99),
(4, 3, 10, 14.99),
(4, 5, 50, 1.99),
(5, 4, 3, 24.99);

-- Insert values into StockMovements
INSERT INTO StockMovements (ProductID, MovementType, Quantity, MovementDate, Description)
VALUES 
(1, 'IN', 50, GETDATE(), 'Initial stock'),
(2, 'IN', 20, GETDATE(), 'Initial stock'),
(3, 'IN', 100, GETDATE(), 'Initial stock'),
(4, 'IN', 15, GETDATE(), 'Initial stock'),
(5, 'IN', 200, GETDATE(), 'Initial stock');

-- Insert values into AuditLogs
INSERT INTO AuditLogs (UserID, Action, TableAffected, ActionTime, Description)
VALUES 
(1, 'INSERT', 'Products', GETDATE(), 'Added new product Smartphone'),
(2, 'INSERT', 'Suppliers', GETDATE(), 'Added new supplier Tech Supply Co.'),
(3, 'UPDATE', 'StockMovements', GETDATE(), 'Updated stock for product Office Chair'),
(4, 'DELETE', 'PurchaseOrders', GETDATE(), 'Deleted cancelled purchase order'),
(5, 'INSERT', 'Users', GETDATE(), 'Created new user manager1');

-- Display all values from Categories
SELECT * FROM Categories;

-- Display all values from Products
SELECT * FROM Products;

-- Display all values from Suppliers
SELECT * FROM Suppliers;

-- Display all values from Users
SELECT * FROM Users;

-- Display all values from PurchaseOrders
SELECT * FROM PurchaseOrders;

-- Display all values from PurchaseOrderDetails
SELECT * FROM PurchaseOrderDetails;

-- Display all values from SalesOrders
SELECT * FROM SalesOrders;

-- Display all values from SalesOrderDetails
SELECT * FROM SalesOrderDetails;

-- Display all values from StockMovements
SELECT * FROM StockMovements;

-- Display all values from AuditLogs
SELECT * FROM AuditLogs;
