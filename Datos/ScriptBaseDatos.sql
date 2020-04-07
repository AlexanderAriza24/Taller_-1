CREATE DATABASE [Copagos];
USE  [Copagos]

CREATE TABLE [dbo].[Copagos](
[Identificacion] [nvarchar](10) NOT NULL PRIMARY KEY,
[ValorServicio] [numeric](18, 0) NULL,
[SalarioTrabajador] [decimal](18, 0) NULL,
[ValorCopago] [numeric](18, 0) NULL,
) 
GO

COMMIT
