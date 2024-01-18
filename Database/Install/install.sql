USE master;
DROP DATABASE IF EXISTS PotionShoppe;
CREATE DATABASE PotionShoppe;
USE PotionShoppe;
CREATE TABLE [EmployeePosition] (
    [EmployeePositionId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR
);
CREATE TABLE [EmployeeStatus] (
    [EmployeeStatusId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR
);
CREATE TABLE [Employee] (
    [EmployeeId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Username] VARCHAR,
    [Password] VARCHAR,
    [Name] VARCHAR,
    [EmployeeStatusId] INT REFERENCES [EmployeeStatus]([EmployeeStatusId]),
    [PositionId] INT REFERENCES [EmployeePosition]([EmployeePositionId]),
);
CREATE TABLE [Customer] (
    [CustomerId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Username] VARCHAR,
    [Password] VARCHAR,
    [Name] VARCHAR
);
CREATE TABLE [Effect] (
    [EffectId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Value] INT,
    [Duration] INT,
    [Description] VARCHAR,
);
CREATE TABLE [Ingredient] (
    [IngredientId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR,
    [Description] VARCHAR,
    [Price] INT,
    [Cost] INT,
    [CurrentStock] INT,
    [Image] INT,
    [EffectId] INT FOREIGN KEY REFERENCES [Effect]([EffectId])
);
CREATE TABLE [OrderStatus] (
    [OrderStatusId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Title] VARCHAR
);
CREATE TABLE [Order] (
    [OrderId] INT IDENTITY(1, 1) PRIMARY KEY,
    [OrderNumber] VARCHAR,
    [CustomerId] INT REFERENCES [Customer]([CustomerId]),
    [OrderStatusId] INT REFERENCES [OrderStatus]([OrderStatusId]),
    [Total] INT,
    [DatePlaced] DATE
);
CREATE TABLE [Receipt] (
    [ReceiptId] INT IDENTITY(1, 1) PRIMARY KEY,
    [ReceiptNumber] VARCHAR,
    [EmployeeId] INT REFERENCES [Employee]([EmployeeId]),
    [OrderId] INT REFERENCES [Order]([OrderId]),
    [DateFulfilled] DATE
);
CREATE TABLE [Potion] (
    [PotionId] INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] VARCHAR,
    [Description] VARCHAR,
    [Price] INT,
    [Cost] INT,
    [CurrentStock] INT,
    [Image] VARCHAR,
    [EmployeeId] INT REFERENCES [Employee]([EmployeeId])
);
CREATE TABLE [PotionEffect] (
    [PotionEffectId] INT IDENTITY(1, 1) PRIMARY KEY,
    [PotionId] INT REFERENCES [Potion]([PotionId]),
    [EffectId] INT REFERENCES [Effect]([EffectId])
);
CREATE TABLE [OrderPotions] (
    [OrderPotionId] INT IDENTITY(1, 1) PRIMARY KEY,
    [PotionId] INT REFERENCES [Potion]([PotionId]),
    [OrderId] INT REFERENCES [Potion]([PotionId])
);
