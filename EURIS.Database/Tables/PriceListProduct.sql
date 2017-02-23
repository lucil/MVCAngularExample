CREATE TABLE [dbo].[PriceListProduct]
(
	[PriceListId] INT NOT NULL,
	[ProductId] INT NOT NULL,

	CONSTRAINT PK_PriceListProduct_PriceListId_ProductId PRIMARY KEY (PriceListId, ProductId),
	CONSTRAINT FK_PriceListProduct_PriceListId FOREIGN KEY (PriceListId) REFERENCES PriceList(PriceListId),
	CONSTRAINT FK_PriceListProduct_ProductId FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
)
