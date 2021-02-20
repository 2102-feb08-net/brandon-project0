
CREATE SCHEMA Project0
GO



CREATE TABLE Project0.Customer (
    CustomerId INT NOT NULL IDENTITY UNIQUE,
    FirstName NVARCHAR(40) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(10),
    Phone NVARCHAR(24),
    Email NVARCHAR(60),
    CONSTRAINT PK_Customer PRIMARY KEY (CustomerId)
)

CREATE TABLE Project0.Product (
    ProductId INT NOT NULL IDENTITY UNIQUE,
    Name NVARCHAR(200),

    UnitPrice NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY (ProductId)
)

CREATE TABLE Project0.Location (
    LocationId INT NOT NULL IDENTITY UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(10),
    Phone NVARCHAR(24),
    Email NVARCHAR(60),
    CONSTRAINT PK_Location PRIMARY KEY (LocationId)
)

CREATE TABLE Project0.[Order] (
    OrderId INT NOT NULL IDENTITY UNIQUE,
    CustomerId INT NOT NULL,
    LocationId INT NOT NULL,
    OrderTime DATETIME NOT NULL,
    OrderTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_Order PRIMARY KEY (OrderId),
    CONSTRAINT FK_Order_CustomerId FOREIGN KEY (CustomerId) REFERENCES Project0.Customer,
    CONSTRAINT FK_Order_LocationId FOREIGN KEY (LocationId) REFERENCES Project0.Location
)

CREATE TABLE Project0.OrderLine (
    OrderLineId INT NOT NULL,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    LineTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_OrderLine PRIMARY KEY (OrderLineId),
    CONSTRAINT FK_OrderLine_OrderId FOREIGN KEY (OrderId) REFERENCES Project0.[Order],
    CONSTRAINT FK_OrderLine_ProductId FOREIGN KEY (ProductId) REFERENCES Project0.Product
)

CREATE TABLE Project0.Inventory (
    InventoryId INT NOT NULL IDENTITY UNIQUE,
    LocationId INT NOT NULL,
    CONSTRAINT PK_Inventory PRIMARY KEY (InventoryId),
    CONSTRAINT FK_Inventory_LocationId FOREIGN KEY (LocationId) REFERENCES Project0.Location
)

CREATE TABLE Project0.InventoryLine (
    InventoryLineId INT NOT NULL IDENTITY UNIQUE,
    InventoryId INT NOT NULL,
    ProductId INT NOT NULL,
    LineTotal NUMERIC(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT PK_InventoryLine PRIMARY KEY (InventoryLineId),
    CONSTRAINT FK_InventoryLine_InventoryId FOREIGN KEY (InventoryId) REFERENCES Project0.Inventory,
    CONSTRAINT FK_InventoryLine_ProductId FOREIGN KEY (ProductId) REFERENCES Project0.Product
)