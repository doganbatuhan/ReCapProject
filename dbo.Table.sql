CREATE TABLE [dbo].[Cars]
(
	[CarId] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] INT NULL, 
    [DailyPrice] DECIMAL NOT NULL, 
    [Description] NCHAR(10) NULL
)
