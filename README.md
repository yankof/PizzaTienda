# PizzaTienda
# Base de datos
# crear la base de datos en microsoft sql server con el nombre de PizzaTienda
IF OBJECT_ID('[dbo].[Producto]', 'U') IS NOT NULL
DROP TABLE [dbo].[Producto]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Producto]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    descripcion NVARCHAR(50),
    abreviacion NVARCHAR(50),
    
    estatus     nvarchar(1),
    creadoPor   nvarchar(60),
    creadoEl    DATETIME,
    -- Specify more columns here

);
GO
-- Create a new table called '[Componentes]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Componentes]', 'U') IS NOT NULL
DROP TABLE [dbo].[Componentes]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Componentes]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Descripcion] NVARCHAR(50) NOT NULL,
    [tipo] NVARCHAR(50) NOT NULL,
    -- Specify more columns here
    estatus     NVARCHAR(1),
    creadoPor   nvarchar(60),
    creadoEl    DATETIME,
    
);
GO
-- Create a new table called '[ProductoComponente]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[ProductoComponente]', 'U') IS NOT NULL
DROP TABLE [dbo].[ProductoComponente]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[ProductoComponente]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    idProducto int not null,
    idComponente int not null,
    -- Specify more columns here
);
GO
-- Create a new table called '[Pedido]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Pedido]', 'U') IS NOT NULL
DROP TABLE [dbo].[Pedido]
GO
-- Create the table in the specified schema

CREATE TABLE [dbo].[Pedido]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [IdCliente] int NOT NULL,
    [nombreCliente] NVARCHAR(50),
    direccionCliente nvarchar(200),
    nitCliente  nvarchar(20),
    telefonoCliente nvarchar(60),

    [idProducto] int,
    [descripcionProducto] NVARCHAR(50),
    
    cantidadProducto decimal(16,2),
    PrecioProducto  decimal(16,2),
    
    PrecioDelivery  DECIMAL(16,2),
    TotalProducto   decimal(16,2),
    -- Specify more columns here
    estatus varchar(1),
    creadoPor varchar(60),
    creadoEl    datetime,
);
go
alter table ProductoComponente add FOREIGN key (idProducto) REFERENCES Producto
go
alter TABLE ProductoComponente add FOREIGN KEY (idComponente) REFERENCES Componentes
GO
-- Create a new table called '[Promocion]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Promocion]', 'U') IS NOT NULL
DROP TABLE [dbo].[Promocion]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Promocion]
(
    IdPromocion int not NULL PRIMARY KEY,
    Nombre NVARCHAR(100),
    tipo nvarchar(5),
    ValorMultiplicador decimal(16,2),

);
GO


# Ejemplos del uso de las apis
