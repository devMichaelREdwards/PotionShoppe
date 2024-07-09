USE master;
DROP DATABASE IF EXISTS PotionShoppe;
CREATE DATABASE PotionShoppe;
USE PotionShoppe;
CREATE TABLE [EmployeePosition] (
    [EmployeePositionId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR(1024)
);
CREATE TABLE [EmployeeStatus] (
    [EmployeeStatusId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR(1024)
);
CREATE TABLE [Employee] (
    [EmployeeId] INT IDENTITY(1, 1) PRIMARY KEY,
    [FirstName] VARCHAR(1024),
    [LastName] VARCHAR(1024),
    [EmployeeStatusId] INT REFERENCES [EmployeeStatus]([EmployeeStatusId]),
    [EmployeePositionId] INT REFERENCES [EmployeePosition]([EmployeePositionId]),
);
Create TABLE [Product] (
    [ProductId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(1024),
    [Description] VARCHAR(1024),
    [Image] VARCHAR(1024),
    [Price] INT,
    [Cost] INT,
    [CurrentStock] INT,
    [DateAdded] DATE,
    [Active] BIT
);
CREATE TABLE [CustomerStatus] (
    [CustomerStatusId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR(1024)
);
CREATE TABLE [Customer] (
    [CustomerId] INT IDENTITY(1, 1) PRIMARY KEY,
    [FirstName] VARCHAR(1024),
    [LastName] VARCHAR(1024),
    [CustomerStatusId] INT REFERENCES [CustomerStatus]([CustomerStatusId]),
);
CREATE TABLE [Effect] (
    [EffectId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR(1024),
    [Value] INT,
    [Duration] INT,
    [Description] VARCHAR(1024),
    [Color] VARCHAR(32)
);
CREATE TABLE [IngredientCategory] (
    [IngredientCategoryId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR(1024)
);
CREATE TABLE [Ingredient] (
    [IngredientId] INT IDENTITY(1, 1) PRIMARY KEY,
    [ProductId] INT FOREIGN KEY REFERENCES [Product]([ProductId]),
    [EffectId] INT FOREIGN KEY REFERENCES [Effect]([EffectId]),
    [IngredientCategoryId] INT FOREIGN KEY REFERENCES [IngredientCategory]([IngredientCategoryId])
);
CREATE TABLE [Potion] (
    [PotionId] INT IDENTITY(1, 1) PRIMARY KEY,
    [ProductId] INT FOREIGN KEY REFERENCES [Product]([ProductId]),
    [EmployeeId] INT REFERENCES [Employee]([EmployeeId])
);
CREATE TABLE [PotionEffect] (
    [PotionEffectId] INT IDENTITY(1, 1) PRIMARY KEY,
    [PotionId] INT REFERENCES [Potion]([PotionId]),
    [EffectId] INT REFERENCES [Effect]([EffectId])
);
CREATE TABLE [OrderStatus] (
    [OrderStatusId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR(1024)
);
CREATE TABLE [Order] (
    [OrderId] INT IDENTITY(1, 1) PRIMARY KEY,
    [OrderNumber] VARCHAR(1024),
    [CustomerId] INT REFERENCES [Customer]([CustomerId]),
    [OrderStatusId] INT REFERENCES [OrderStatus]([OrderStatusId]),
    [Total] INT,
    [DatePlaced] DATE
);
CREATE TABLE [Receipt] (
    [ReceiptId] INT IDENTITY(1, 1) PRIMARY KEY,
    [ReceiptNumber] VARCHAR(1024),
    [EmployeeId] INT REFERENCES [Employee]([EmployeeId]),
    [OrderId] INT REFERENCES [Order]([OrderId]),
    [DateFulfilled] DATE
);
;
CREATE TABLE [OrderProduct] (
    [OrderProductId] INT IDENTITY(1, 1) PRIMARY KEY,
    [ProductId] INT REFERENCES [Product]([ProductId]),
    [OrderId] INT REFERENCES [Order]([OrderId]),
    [Quantity] INT
);
CREATE TABLE [CustomerAccount] (
    [CustomerAccountId] INT IDENTITY(1, 1) PRIMARY KEY,
    [UserName] NVARCHAR(450),
    [Email] NVARCHAR(1024),
    [CustomerId] INT REFERENCES [Customer]([CustomerId]),
    [RefreshToken] VARCHAR(1024),
    [TokenExpire] DATE
);
CREATE TABLE [EmployeeAccount] (
    [EmployeeAccountId] INT IDENTITY(1, 1) PRIMARY KEY,
    [UserName] NVARCHAR(450),
    [Email] NVARCHAR(1024),
    [EmployeeId] INT REFERENCES [Employee]([EmployeeId]),
    [RefreshToken] VARCHAR(1024),
    [TokenExpire] DATE
);
