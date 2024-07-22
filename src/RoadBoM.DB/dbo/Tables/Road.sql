CREATE TABLE [dbo].[Road]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(50) NULL, 
    [Length] DECIMAL(18, 2) NULL, 
    [Width] DECIMAL(18, 2) NULL, 
    [Row] DECIMAL(18, 2) NULL, 
    [Poles] INT NULL, 
    [Type] NVARCHAR(50) NULL, 
    [Culvert] INT NULL, 
    [Outfall] INT NULL, 
    [Status] INT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [UpdatededOn] DATETIME NULL
)
