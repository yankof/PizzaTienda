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
# metodo api/Pedido/InsertAsync
# modificando la fecha se puede ver la regla de los descuentos embebida en el programa
{
  "id": 5,
  "idCliente": 1,
  "nombreCliente": "juan perez",
  "direccionCliente": "los tecos",
  "nitCliente": "5338119",
  "telefonoCliente": "777888555",
  "idProducto": 1,
  "descripcionProducto": "Pizza hawaiana carnivora",
  "cantidadProducto": 1.00,
  "precioProducto": 150.00,
  "precioDelivery": 10.00,
  "totalProducto": 160.00,
  "estatus": "1",
  "creadoPor": "Admin",
  "creadoEl": "2024-11-12T05:52:39.852Z"
}

# metodo api/Producto/InsertAsync
{
  "id": 4,
  "descripcion": "Pizza quesuna",
  "abreviacion": "Quesun",
  "estatus": "1",
  "creadoPor": "Admin",
  "creadoEl": "2024-11-17T21:23:17.672Z"
}

Ejemplo de uso
https://app.screencast.com/LpJoGE3HecMNs




