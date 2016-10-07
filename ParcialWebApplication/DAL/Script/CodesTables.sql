use Parcial1Db;


create table Solicitudes(
 IdSolicitud int identity(1,1) primary key,
 Fecha varchar(20),
 Razon varchar(100),
 Total float
);

create table Materiales(
 IdMaterial int identity(1,1) primary key,
 Descripcion varchar(200),
 Precio float
);

create table SolicitudesDetalle(
 Id int identity(1,1) primary key,
 IdSolicitud int references Solicitudes(idSolicitud),
 IdMaterial int references Materiales(IdMaterial),
 Cantidad int,
);


insert into Materiales(Descripcion, Precio)
 values('Gorra', 250.25);

 insert into Materiales(Descripcion, Precio)
 values('Sueter', 300.55);

 insert into Materiales(Descripcion, Precio)
 values('Pantalon', 850.85);