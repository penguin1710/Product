create database Product
go
use Product
go

create table Product(
	id int identity(1,1) primary key,
	Name nvarchar(max) not null,
	Price int not null,
	Expire Date not null
)