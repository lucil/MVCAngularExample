CREATE TABLE [dbo].[PriceList]
(
	[PriceListId] INT NOT NULL IDENTITY(1,1),
	[PriceListCode] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(250) NULL,

	CONSTRAINT PK_PriceList_PriceListId PRIMARY KEY (PriceListId)

)
