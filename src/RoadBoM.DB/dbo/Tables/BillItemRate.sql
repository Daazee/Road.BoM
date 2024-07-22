CREATE TABLE [dbo].[BillItemRate]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[BillItemId] BIGINT  NOT NULL,
	[RateType]  NVARCHAR(20) NOT NULL,
	[Amount] decimal(18,2) NULL,
	[Status] INT NOT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NOT NULL, 
    [UpdatedBy] NVARCHAR(50) NOT NULL, 
    [UpdatededOn] DATETIME NOT NULL,
	FOREIGN KEY (BillItemId) REFERENCES BillItem (Id)
)
