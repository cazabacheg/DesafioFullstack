Use Master
go

if exists(Select * from sys.databases  Where name='DesafioFullstack')
Begin
	Drop Database DesafioFullstack
End
go

create database DesafioFullstack
go

USE DesafioFullstack
go

set dateformat ymd
go

-----------------------CREACION TABLA CATEGORIAS------------------------------------------
CREATE TABLE tb_categorias (
  IdCategoria int primary key ,
  NombreCategoria varchar(15) not null,
  Descripcion text
)
go

---------------------REGISTRO DE CATEGORIAS------------------------------------------
INSERT INTO tb_categorias  VALUES(1, 'Bebidas', 'Gaseosas, cafe, te, cervezas y maltas')
INSERT INTO tb_categorias  VALUES(2, 'Condimentos', 'Salsas dulces y picantes, delicias, comida para untar y aderezos')
INSERT INTO tb_categorias  VALUES(3, 'Reposteria', 'Postres, dulces y pan dulce')
INSERT INTO tb_categorias  VALUES(4, 'Lacteos', 'Quesos')
INSERT INTO tb_categorias  VALUES(5, 'Granos/Cereales', 'Pan, galletas, pasta y cereales')
INSERT INTO tb_categorias  VALUES(6, 'Carnes', 'Carnes preparadas')
INSERT INTO tb_categorias  VALUES(7, 'Frutas/Verduras', 'Frutas secas y queso de soja')
INSERT INTO tb_categorias  VALUES(8, 'Pescado/Marisco', 'Pescados, mariscos y algas')
go

--------------------CREACION TABLA PRODUCTOS------------------------------------
CREATE TABLE tb_productos (
  IdProducto varchar(7) primary key,
  NombreProducto varchar(40) not null,
  IdCategoria int References tb_categorias,
  PrecioUnidad decimal(10,2) not null)
go

--------------------REGISTRO DE PRODUCTOS--------------------------------------------
INSERT INTO tb_productos VALUES('PRO-001', 'Te Dharamsala', '1' ,'18.99')
INSERT INTO tb_productos VALUES('PRO-002', 'Cerveza tibetana Barley', '1', '19.99')
INSERT INTO tb_productos VALUES('PRO-003', 'Sirope de regaliz', '2', '10.55')
INSERT INTO tb_productos VALUES('PRO-004', 'Especias Cajun del chef Anton', '2', '22.45')
INSERT INTO tb_productos VALUES('PRO-005', 'Mezcla Gumbo del chef Anton', '2','21.99')
INSERT INTO tb_productos VALUES('PRO-006', 'Mermelada de grosellas de la abuela', '2','24.99')
INSERT INTO tb_productos VALUES('PRO-007', 'Peras secas organicas del tio Bob', '7', '30.50')
INSERT INTO tb_productos VALUES('PRO-008', 'Salsa de arandanos Northwoods', '2', '40.30')
INSERT INTO tb_productos VALUES('PRO-009', 'Buey Mishi Kobe', '6', '99.99')
INSERT INTO tb_productos VALUES('PRO-010', 'Pez espada', '8', '30.45')
go

-------------------------------PROCEDIMIENTOS-------------------------------------

--FUNCION PARA GENERAR EL CORRELATIVO AUTOMATICAMENTE
create or alter function dbo.autogenera() returns varchar(7)
As
Begin

	Declare @n int --N es el contador
	Declare @cod varchar(7)=(Select top 1 IdProducto from tb_productos order by 1 desc)

	if(@cod is null)

		Set @n=1
	else

		Set @n=CAST(subString(@cod,4,7) as int)+1 

	return CONCAT('PRO-',REPLICATE('0',3-LEN(@n)),@n)
End
go

------------------TABLA CATEGORIAS--------------
----------LISTAR--------------

create or alter proc p_categorias_listar
as
select *from tb_categorias
go

------------------TABLA PRODUCTOS------------

---------LISTAR----------------

create or alter proc p_producto_listar
as
select *from tb_productos
go

---------INSERTAR-----------

create or alter proc p_producto_inserta

@cod varchar(7) output,
@nomp varchar(100),
@idcategoria int,
@preUni decimal(10,2)
as
	begin
		Set @cod=dbo.autogenera()
		insert into tb_productos values(@cod,@nomp,@idcategoria, @preUni)
	end
go

--------ACTUALIZAR--------------

create or alter proc p_producto_actualizar

@cod varchar(7) output,
@nomp varchar(100),
@idcategoria int,
@preUni decimal(10,2)
as
	begin
		Update tb_productos
		Set NombreProducto=@nomp, IdCategoria=@idcategoria,PrecioUnidad=@preUni
		Where IdProducto=@cod
	end
go

--------ELIMINAR--------------

create or alter proc p_producto_delete

@cod varchar(7)

as
delete from tb_productos Where IdProducto=@cod
go