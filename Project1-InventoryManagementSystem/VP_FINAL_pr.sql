CREATE TABLE PurchaseOrders (
    PurchaseOrderId INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment primary key
    ProductId INT NOT NULL,                       -- Foreign key to Products table
    ProductName VARCHAR(255) NOT NULL,            -- Name of the product
    SupplierId INT NOT NULL,                      -- Foreign key to Suppliers table
    SupplierName VARCHAR(255) NOT NULL,           -- Name of the supplier
    Quantity INT NOT NULL,                        -- Quantity of products purchased
    TotalCost DECIMAL(18, 2) NOT NULL,            -- Total cost of the purchase
    OrderDate DATETIME NOT NULL DEFAULT GETDATE() -- Date of the purchase
);

select *from Products
select *from Users