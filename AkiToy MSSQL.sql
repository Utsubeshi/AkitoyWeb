/*
use master
if db_id ( 'AkiToy' ) is not null
  drop database AkiToy
go

create database AkiToy
go

use AkiToy
go

set dateformat dmy
go


CREATE TABLE Departamento
(
    idDpto int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50) UNIQUE not null
)

CREATE TABLE Provincia
(
    idProvincia int IDENTITY PRIMARY KEY,
    idDpto int FOREIGN KEY REFERENCES Departamento(idDpto),
    Detalle VARCHAR(50) UNIQUE not NULL
)

create TABLE Distrito
(
    idDistrito int IDENTITY PRIMARY KEY,
    idProvincia int FOREIGN KEY REFERENCES Provincia(idProvincia),
    Detalle VARCHAR(50) UNIQUE not NULL
)

CREATE TABLE Direccion
(
    idDireccion int IDENTITY PRIMARY KEY,
    Direccion VARCHAR(50) not null,
    Apodo varchar(20),
    idDpto int FOREIGN KEY REFERENCES Departamento(idDpto),
    idProvincia int FOREIGN KEY REFERENCES Provincia(idProvincia),
    idDistrito int FOREIGN KEY REFERENCES Distrito(idDistrito)
)

create table Cliente
(
    idCliente int identity primary key,
    DNI VARCHAR(8) UNIQUE,
    Nombre VARCHAR(50),
    Paterno VARCHAR(50),
    Materno VARCHAR(50),
    Email VARCHAR(50) UNIQUE,
    Pass VARCHAR(30),
    Celular VARCHAR(9),
    idDireccion int FOREIGN KEY REFERENCES Direccion(idDireccion),
    Eliminado bit,
    EliminadoPor int
)

CREATE TABLE ClienteDireccion
(
    idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente),
    idDireccion INT FOREIGN KEY REFERENCES Direccion(idDireccion)
)

CREATE TABLE Courier
(
    idCourier int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50),
    Direccion VARCHAR(50) not null,
    Telefono VARCHAR(10)
)

CREATE TABLE Usuario
(
    idUsuario INT IDENTITY PRIMARY KEY,
    DNI VARCHAR(8) UNIQUE,
    Nombre VARCHAR(50),
    Paterno VARCHAR(50),
    Materno VARCHAR(50),
    Email VARCHAR(50) UNIQUE,
    Pass VARCHAR(30),
    Eliminado bit,
    EliminadoPor int
)

CREATE TABLE Pago
(
    idPago int IDENTITY PRIMARY KEY,
    Token VARCHAR(50),
    Valido BIT
)

CREATE TABLE Estado --estado de los productos puede ser nuevo / usado
(
    idEstado int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50),
)

CREATE TABLE Serie --serie de anime, manga o juego al que pertenece la figura
(
    idSerie int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50)
)

CREATE TABLE Marca
(
    idMarca int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50)
)

CREATE TABLE Categoria
(
    idCategoria int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50)
)

CREATE TABLE Linea --linea a la cual pertenece el producto, ejemplo figma/nedoroid
(
    idLinea int IDENTITY PRIMARY KEY,
    Detalle VARCHAR(50)
)

CREATE TABLE Producto
(
    idProducto INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(50) not null,
    Detalle VARCHAR(50) not null,
    PrecioCosto Decimal(19,4), --incluye el costo de envio internacional
    PrecioVenta Decimal(19,4),
    Descuento Decimal (2,1),
    Stock int,
    FechaIngreso DATE,
    FechaLanzamiento DATE,
    Peso Decimal(5,3),
    Dimensiones VARCHAR(20),
    idMarca int,
    idEstado int,
    idSerie int,
    idLinea int,
    idCategoria int,
    Eliminado BIT, 
    EliminadorPor int -- id del usuario q elimino el producto del inventario
)

CREATE TABLE Reserva
(
    idReserva int IDENTITY PRIMARY KEY,
    Fecha DATE not null,
    idProducto int FOREIGN KEY REFERENCES Producto(idProducto),
    idCliente int FOREIGN KEY REFERENCES Cliente(idCliente),
    idPago int FOREIGN KEY REFERENCES Pago(idPago)
)

CREATE TABLE PedidoDetalle
(
    idPedido int,
    idProducto int,
    Cantidad int,
    Estado int -- En curso / listo para envio / finalizado / cancelado
)

CREATE TABLE Envio
(
    idEnvio int IDENTITY PRIMARY KEY,
    CodigoEnvio VARCHAR(50),
    Precio Decimal(19,4),
    FechaSalida DATE,
    idCourier int FOREIGN KEY REFERENCES Courier(idCourier),
    idUsuario int FOREIGN KEY REFERENCES Usuario(idUsuario)
)

CREATE TABLE Pedido
(
    idPedido int IDENTITY PRIMARY KEY,
    Fecha DATE not null,
    idCliente int FOREIGN KEY REFERENCES Cliente(idCliente),
    idEnvio int FOREIGN KEY REFERENCES Envio(idEnvio),
    Token VARCHAR(50),
)

*/

ALTER TABLE Producto
ADD FOREIGN KEY (idMarca) REFERENCES Marca(idMarca)

ALTER TABLE Producto
ADD FOREIGN KEY (idEstado) REFERENCES Estado(idEstado)

ALTER TABLE Producto
ADD FOREIGN KEY (idSerie) REFERENCES Serie(idSerie)

ALTER TABLE Producto
ADD FOREIGN KEY (idLinea) REFERENCES Linea(idLinea)

ALTER TABLE Producto
ADD FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)

ALTER TABLE PedidoDetalle
ADD FOREIGN KEY (idPedido) REFERENCES Pedido(idPedido)

ALTER TABLE PedidoDetalle
ADD FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)

insert into Marca values('Medicom Toy'),
('Max Factory'),
('Takara Tomy'),
('Good Smile Company'),
('KADOKAWA'),
('BANDAI SPIRITS'),
('Square Enix')


insert into Estado values('Nuevo')


insert into Serie values('Legend of Zelda'),
('Sword Art Online Alternative GGO'),
('KonoSuba'),
('My Hero Academia'),
('Fire Emblem Fates'),
('One-Punch Man'),
('Re:ZERO -Starting Life in Another World'),
('DARLING in the FRANXX'),
('Final Fantasy IX')


insert into Linea values('Real Action Heroes'),
('Figma'),
('Nendoroid'),
('KDColle'),
('S.H. Figuarts'),
('FINAL FANTASY IX BRING ARTS')

insert into Categoria values('Figura Articulable'),
('Estatua')

go

/*
insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Link - Breath of the Wild','Sellado',1050,1200,0,3,GETDATE(),'20180301',1.5,300,1,1,1,1,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Gun Gale Online','Sellado',200,250,0,3,GETDATE(),'20200401',0.350,130,2,1,2,2,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Darkness','Sellado',200,250,0,3,GETDATE(),'20200401',0.350,140,2,1,3,2,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Izuku Midoriya','Sellado',210,270,0,3,GETDATE(),'20191201',0.350,140,3,1,4,2,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Corrin (Female)','Sellado',135,180,0,3,GETDATE(),'20191001',0.350,120,4,1,5,6,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Garou - Super Movable Edition','Sellado',135,185,0,3,GETDATE(),'20191101',0.400,130,4,1,6,3,1,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Rem & Subaru: Attack on the White Whale','Sellado',815,950,0,3,GETDATE(),'20200301',1.5,300,5,1,7,4,2,0)

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Zero Two','Sellado',185,235,0,3,GETDATE(),'20181001',0.400,140,6,1,8,5,1,0)

*/
go

insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values('Kuja & Amarant Coral','Sellado',600,699,0,3,GETDATE(),'20200401',1.2,165/185,7,1,9,6,1,0)

go

--CRUD Producto
--Insertar Producto

create proc InsertarProducto
@Nombre varchar(50),
@Detalle varchar(50),
@PrecioCosto decimal(19,4),
@PrecioVenta decimal(19,4),
@Descuento decimal(2,1),
@Stock int,
@FechaLanzamiento date,
@Peso decimal(5,3),
@Dimensiones varchar(20),
@idMarca int,
@idEstado int,
@idSerie int,
@idLinea int,
@idCategoria int
as
insert into Producto(Nombre, Detalle,PrecioCosto,PrecioVenta,Descuento,Stock,FechaIngreso,FechaLanzamiento,Peso,Dimensiones,idMarca,
					idEstado,idSerie,idLinea,idCategoria,Eliminado)
values(@Nombre,@Detalle,@PrecioCosto,@PrecioVenta,@Descuento,@Stock,GETDATE(),@FechaLanzamiento,@Peso,@Dimensiones,@idMarca,@idEstado,@idSerie,@idLinea,@idCategoria,0)
go

--Listar Ultimos productos ingresados para la portada

create proc ListaDePortada
as
select idProducto,Nombre,PrecioVenta,FechaIngreso from Producto ORDER BY FechaIngreso DESC
go

exec ListaDePortada
go

create proc sp_ListaProductos
@eliminado bit
as
select	idProducto as 'ID',
		Nombre as 'Producto',
		p.Detalle,
		cast(PrecioCosto as money) as 'Costo', 
		cast(PrecioVenta as money) as 'Precio venta',
		Stock,
		Format(FechaIngreso, 'dd/MM/yyyy ') as 'Fecha de Ingreso',
		Format(FechaLanzamiento, 'MMM/yyyy ') as 'Mes de Lanzamiento' ,
		Peso,
		Dimensiones,
		m.Detalle as 'Marca',
		e.Detalle as 'Estado',
		s.Detalle as 'Serie',
		l.Detalle as 'Linea',
		c.Detalle as 'Categoria' 
from Producto p
		inner join Marca m on m.idMarca = p.idMarca
		inner join Estado e on e.idEstado = p.idEstado
		inner join Serie s on s.idSerie = p.idSerie
		inner join Linea l on l.idLinea = p.idLinea
		inner join Categoria c on c.idCategoria = p.idCategoria
where Eliminado = @eliminado
order by Nombre
go


create proc GetProductoPorId
@id int
as
select 
		idProducto,
		Nombre,
		Detalle,
		PrecioCosto,
		PrecioVenta,
		Descuento,
		Stock,
		Format(FechaIngreso, 'dd/MM/yyyy ') as 'Fecha de Ingreso',
		Format(FechaLanzamiento, 'MMM/yyyy ') as 'Mes de Lanzamiento', 		
		Peso,
		Dimensiones,
		idMarca,
		idEstado,
		idSerie,
		idLinea,
		idCategoria,
		Eliminado,
		EliminadorPor
from Producto where idProducto = @id
go

exec GetProductoPorId 10

select * from Usuario

insert into Usuario(DNI,Nombre,Paterno,Materno,Email,Pass,Eliminado) values
('40393954','Juan','Niño','Salas','asdf@gmail.com','1234',0)

select * from Producto

alter table producto
alter column FechaIngreso Date  null