USE master;  
GO  

--if exists drop database
IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Euris')
DROP DATABASE [Euris]
GO

--create database
CREATE DATABASE Euris;  
GO  

--create login user
IF NOT EXISTS (SELECT loginname FROM master.dbo.syslogins 
    WHERE name = 'euris')
BEGIN
	CREATE LOGIN euris WITH PASSWORD = 'euris'
END
GO
--set default database to login user
ALTER LOGIN euris WITH DEFAULT_DATABASE = Euris
GO

USE Euris;
GO

--create database user for login
CREATE USER Euris FOR LOGIN Euris;  
GO  

--adding read/write
EXEC sp_addrolemember N'db_datareader', N'euris'
EXEC sp_addrolemember N'db_datawriter', N'euris'
GO

--PriceList
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PriceList' AND xtype='U')
BEGIN
	CREATE TABLE [dbo].[PriceList]
	(
		[PriceListId] INT NOT NULL IDENTITY(1,1),
		[PriceListCode] NVARCHAR(50) NOT NULL,
		[Description] NVARCHAR(250) NULL,

		CONSTRAINT PK_PriceList_PriceListId PRIMARY KEY (PriceListId)

	)
END
GO

--Product
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Product' AND xtype='U')
BEGIN
	CREATE TABLE [dbo].[Product]
	(
		[ProductId] INT NOT NULL IDENTITY(1,1),
		[ProductCode] NVARCHAR(50) NOT NULL,
		[Description] NVARCHAR(250) NULL,

		CONSTRAINT PK_Product_ProductId PRIMARY KEY (ProductId)
	)
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PriceListProduct' AND xtype='U')
BEGIN
	CREATE TABLE [dbo].[PriceListProduct]
	(
		[PriceListId] INT NOT NULL,
		[ProductId] INT NOT NULL,

		CONSTRAINT PK_PriceListProduct_PriceListId_ProductId PRIMARY KEY (PriceListId, ProductId),
		CONSTRAINT FK_PriceListProduct_PriceListId FOREIGN KEY (PriceListId) REFERENCES PriceList(PriceListId),
		CONSTRAINT FK_PriceListProduct_ProductId FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
	)
END
GO