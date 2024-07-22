CREATE TABLE [dbo].[BillCategory]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Code] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Order] decimal NULL,
    [Status] INT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [UpdatededOn] DATETIME NULL
)
