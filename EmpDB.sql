use EmployeeDB;
go

create table Employees
(
      Id int primary key,
      Name nvarchar(50) not null,
      Salary int not null,
      City varchar(110) null, 
      Age int null
);
go
create procedure sp_Employees_GetAll
as begin
     select
      Id,
	  Name,
	  Salary,
	  City,
	  Age
from Employees
end
go

create procedure sp_Employees_Get
    @Id int
as begin
     select
      Id,
	  Name,
	  Salary,
	  City,
	  Age
from Employees
where Id=@Id
end
go



create procedure sp_Employees_Create
      @Id int,
	  @Name nvarchar(300),
	  @Salary int,
	  @City nvarchar(100),
	  @Age int
as begin
insert into Employees( 
	  Name,
	  Salary,
	  City,
	  Age )
values(
	  @Name,
	  @Salary,
	  @City,
	  @Age);
end
go



create procedure sp_Employees_Create
      @Id int,
	  @Name nvarchar(300),
	  @Salary int,
	  @City nvarchar(100),
	  @Age int
as begin
insert into Employees( 
	  Name,
	  Salary,
	  City,
	  Age )
values(
	  @Name,
	  @Salary,
	  @City,
	  @Age);
end
go

select 
      Id,
	  Name,
	  Salary,
	  City,
	  Age
from Employees 
where Id=(select Scope=IDENTITY());
end
go

create procedure sp_Employees_Delete
    @Id int
as begin
      delete from Emlpoyees
	  where 
	     Id = @Id
end
go