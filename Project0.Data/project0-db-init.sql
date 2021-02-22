
CREATE SCHEMA Project0
GO


/*******************************************************************************
   Create Tables
********************************************************************************/

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
    Email NVARCHAR(60) NOT NULL,
    CONSTRAINT PK_Customer PRIMARY KEY (CustomerId)
)

CREATE TABLE Project0.Product (
    ProductId INT NOT NULL IDENTITY UNIQUE,
    Name NVARCHAR(200) NOT NULL,
    BestBy DATETIME,
    UnitPrice NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_Product PRIMARY KEY (ProductId)
)

CREATE TABLE Project0.Location (
    LocationId INT NOT NULL IDENTITY UNIQUE,
    StoreNumber INT NOT NULL,
    Address NVARCHAR(70),
    City NVARCHAR(40),
    State NVARCHAR(40),
    Country NVARCHAR(40),
    PostalCode NVARCHAR(10),
    Phone NVARCHAR(24) NOT NULL,
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
    OrderLineId INT NOT NULL IDENTITY UNIQUE,
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
    LastUpdate DATETIME NOT NULL,
    CONSTRAINT PK_Inventory PRIMARY KEY (InventoryId),
    CONSTRAINT FK_Inventory_LocationId FOREIGN KEY (LocationId) REFERENCES Project0.Location
)

CREATE TABLE Project0.InventoryLine (
    InventoryLineId INT NOT NULL IDENTITY UNIQUE,
    InventoryId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    LineTotal NUMERIC(10, 2) NOT NULL,
    CONSTRAINT PK_InventoryLine PRIMARY KEY (InventoryLineId),
    CONSTRAINT FK_InventoryLine_InventoryId FOREIGN KEY (InventoryId) REFERENCES Project0.Inventory,
    CONSTRAINT FK_InventoryLine_ProductId FOREIGN KEY (ProductId) REFERENCES Project0.Product
)



/*******************************************************************************
   Populate Tables
********************************************************************************/



INSERT INTO Project0.Customer (FirstName, LastName, Address, City, State, Country, PostalCode, Phone, Email) VALUES
    ('Lauren', 'Lister', '101 Alpha Way',    'Fantasy Heights', NULL, 'Hypothetican Republic', NULL, NULL, 'llister@emailhost.net'),
    ('Kaiser', 'Avalos', '258 Omega Blvd.',  'Mythopolis',      NULL, 'Hypothetican Republic', NULL, NULL, 'kavalos@emailhost.net'),
    ('Rianne', 'Fry',    '741 Tango Ave.',   'New Simula',      NULL, 'Hypothetican Republic', NULL, NULL, 'rfry@emailhost.net'),
    ('Isaac', 'Bailey',  '121 Alpha Way',    'New Simula',      NULL, 'Hypothetican Republic', NULL, NULL, 'ibailey@emailhost.net'),
    ('Enzo', 'Drew',     '369 Delta Dr.',    'Fantasy Heights', NULL, 'Hypothetican Republic', NULL, NULL, 'edrew@emailhost.net');

INSERT INTO Project0.Location (StoreNumber, Address, City, State, Country, PostalCode, Phone) VALUES
    (1,   '123 1st Street', 'Mythopolis',       NULL, 'Hypothetican Republic', NULL, '202-555-0128'),
    (23,  '531 2nd Street', 'New Simula',       NULL, 'Hypothetican Republic', NULL, '202-555-0137'),
    (157, '529 2nd Street', 'Fantasy Heights',  NULL, 'Hypothetican Republic', NULL, '202-555-0165');

INSERT INTO Project0.Product (Name, BestBy, UnitPrice) VALUES
    ('Hammer', NULL, 9.99),
    ('Nails, 1 lb', NULL, 2.49),
    ('Toolbox', NULL, 49.99),
    ('Milk, 1 Gallon', '2021/3/1', 3.49),
    ('Sandwich Bread, Loaf, Sliced', '2021/3/21', 1.99),
    ('Eggs, 1 Dozen', '2021/4/1', 3.99),
    ('Roast Beef, 1 lb', '2021/4/1', 2.99),
    ('Swiss Cheese, 1 lb', '2021/5/16', 2.49),
    ('Turkey, Whole', '2021/4/1', 19.99);

INSERT INTO Project0.Inventory (LocationId, LastUpdate) VALUES
    (1, '2021/2/21'),
    (2, '2021/2/21'),
    (3, '2021/2/21');

INSERT INTO Project0.InventoryLine (InventoryId, ProductId, Quantity, LineTotal) VALUES
    (1, 1, 30, 299.70),
    (1, 2, 100, 249.00),
    (1, 3, 15, 749.85),
    (1, 4, 30, 104.70),
    (1, 5, 30, 59.70),
    (1, 6, 30, 119.70),
    (1, 7, 50, 149.50),
    (1, 8, 25, 62.25),
    (1, 9, 15, 299.85),
    (2, 1, 30, 299.70),
    (2, 2, 100, 249.00),
    (2, 3, 15, 749.85),
    (2, 4, 30, 104.70),
    (2, 5, 30, 59.70),
    (2, 6, 30, 119.70),
    (2, 7, 50, 149.50),
    (2, 8, 25, 62.25),
    (2, 9, 15, 299.85),
    (3, 1, 30, 299.70),
    (3, 2, 100, 249.00),
    (3, 3, 15, 749.85),
    (3, 4, 30, 104.70),
    (3, 5, 30, 59.70),
    (3, 6, 30, 119.70),
    (3, 7, 50, 149.50),
    (3, 8, 25, 62.25),
    (3, 9, 15, 299.85);

INSERT INTO Project0.[Order] (CustomerId, LocationId, OrderTime, OrderTotal) VALUES
    (1, 2, '2021/2/21', 3.98),
    (2, 1, '2021/2/21', 12.45),
    (3, 3, '2021/2/21', 8.79),
    (4, 2, '2021/2/21', 3.99),
    (5, 3, '2021/2/21', 4.98);

INSERT INTO Project0.OrderLine (OrderId, ProductId, Quantity, LineTotal) VALUES
    (1, 5, 2, 3.98),
    (2, 2, 5, 12.45),
    (3, 7, 3, 8.79),
    (4, 6, 1, 3.99),
    (5, 8, 2, 4.98);
