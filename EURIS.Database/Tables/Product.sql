CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL IDENTITY(1,1),
	[ProductCode] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(250) NULL,

	CONSTRAINT PK_Product_ProductId PRIMARY KEY (ProductId)
)
