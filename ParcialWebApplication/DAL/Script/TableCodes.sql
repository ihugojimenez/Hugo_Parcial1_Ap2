use Parcial1Db;

drop table MaterialesDetalle;

create table SolicitudMateriales(
 Id int identity(1,1) primary key,
 IdMaterial int references MaterialesDetalle(Id),
 Razon varchar(100)
);

create table MaterialesDetalle(
 Id int identity(1,1) primary key,
 Desripcion varchar(200)

);