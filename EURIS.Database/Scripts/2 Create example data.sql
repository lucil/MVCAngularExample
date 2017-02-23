USE Euris;
GO

--delete existing data
TRUNCATE TABLE [dbo].[PriceListProduct];
GO
DELETE FROM [dbo].[Product];
GO
DELETE FROM [dbo].[PriceList];
GO

--reset identity
DBCC CHECKIDENT ('[Product]', RESEED, 0);
GO

DBCC CHECKIDENT ('[PriceList]', RESEED, 0);
GO

--insert example data
INSERT INTO Product(ProductCode, Description)
VALUES ('A001', 'Pantaloni Tattini da donna modello Dafne.'),
('A002', 'Stivaletto basso tecnico Oxford by Barkley in pelle con cerniera frontale.'),
('A003', 'Copricasco impermeabile anti pioggia, in 100% polipropilene trasparente, molto resistente.'),
('A004', 'Polo classica da gara, a manica corta, tessuto 100% cotone.'),
('A005', 'Cintura elastica intrecciata BILLYBELT fina da donna (2cm).')
GO

--insert example data
INSERT INTO PriceList(PriceListCode, Description)
VALUES ('S01', 'Listino standard.'),
('S02', 'Offerta speciale.'),
('S03', 'Listino senza prodotti.')
GO

INSERT INTO PriceListProduct (PriceListId, ProductId)
VALUES(1,1),
	(1,2),
	(1,3),
	(1,4),
	(2,1),
	(2,4)
GO