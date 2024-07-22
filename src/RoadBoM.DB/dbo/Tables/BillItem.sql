CREATE TABLE [dbo].[BillItem]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Code] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Unit] NVARCHAR(100) NULL, 
    [Order] FLOAT NOT NULL,
    [Status] INT NOT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NOT NULL, 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
    [UpdatededOn] DATETIME NOT NULL
)
