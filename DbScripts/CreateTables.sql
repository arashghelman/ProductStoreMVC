use ProductStore
go
CREATE TABLE dbo.Category
(
    Id int primary key identity(1,1),
    CategoryName nvarchar(max)
)
go
CREATE TABLE dbo.Product
(
    Id int primary key identity(1,1),
    Category_Ref int foreign key references Category(Id),
	ProductName nvarchar(max),
	UnitPrice money,
	Discount money,
	Quantity int,
	ProductPhoto varbinary(max)
);