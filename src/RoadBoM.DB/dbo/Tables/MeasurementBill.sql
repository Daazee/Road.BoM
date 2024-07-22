CREATE TABLE [dbo].[MeasurementBill]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY(1,1),
	Quantity decimal not null,
	BillCategoryId bigint not null,
	BillItemId  bigint not null,
	BillItemRateId int not null,
	CreatedFrom  int null,
	[Status] INT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] NVARCHAR(50) NULL, 
	--Foreign Key BillCategoryId on 
)
