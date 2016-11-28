CREATE DATABASE LineyschikovCoreContext
GO
USE LineyschikovCoreContext
GO

CREATE TABLE [dbo].[Customers] (
	[Id] [int] NOT NULL IDENTITY,
	[Name] [nvarchar](max),
	[Address] [nvarchar](max),
	[Vip] [bit] NOT NULL,
	CONSTRAINT [PK_dbo.Customers] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Orders] (
	[Id] [int] NOT NULL IDENTITY,
	[Description] [nvarchar](max),
	[CustomerId] [int] NOT NULL,
	CONSTRAINT [PK_dbo.Orders] PRIMARY KEY (Id)
)
CREATE INDEX [IX_CustomerId] ON [dbo].[Orders]([CustomerId])
ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_dbo.Orders_dbo.Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE