IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'MillionAndUp')
BEGIN
CREATE DATABASE [MillionAndUp]


END
GO
    USE [MillionAndUp]
GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Owner] (
    [IdOwner] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    [Address_City] nvarchar(150) NOT NULL,
    [Address_State] nvarchar(150) NOT NULL,
    [Address_Line1] nvarchar(150) NOT NULL,
    [Address_Line2] nvarchar(150) NOT NULL,
    [Address_ZipCode] nvarchar(150) NOT NULL,
    [Photo] nvarchar(250) NOT NULL,
    [Birthay] datetime2 NOT NULL,
    [Enabled] bit NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY ([IdOwner])
);
GO

CREATE TABLE [Property] (
    [IdProperty] int NOT NULL IDENTITY,
    [Name] nvarchar(250) NOT NULL,
    [Address_City] nvarchar(150) NOT NULL,
    [Address_State] nvarchar(150) NOT NULL,
    [Address_Line1] nvarchar(150) NOT NULL,
    [Address_Line2] nvarchar(150) NOT NULL,
    [Address_ZipCode] nvarchar(150) NOT NULL,
    [PriceSale] float(28) NOT NULL,
    [CodeInternal] nvarchar(50) NOT NULL,
    [YearBuild] int NOT NULL,
    [IdOwner] int NOT NULL,
    [Enabled] bit NOT NULL,
    CONSTRAINT [PK_Property] PRIMARY KEY ([IdProperty]),
    CONSTRAINT [FK_Property_Owner_IdOwner] FOREIGN KEY ([IdOwner]) REFERENCES [Owner] ([IdOwner]) ON DELETE CASCADE
);
GO

CREATE TABLE [PropertyImage] (
    [IdPropertyImage] int NOT NULL IDENTITY,
    [IdProperty] int NOT NULL,
    [File] nvarchar(250) NOT NULL,
    [Enabled] bit NOT NULL,
    CONSTRAINT [PK_PropertyImage] PRIMARY KEY ([IdPropertyImage]),
    CONSTRAINT [FK_PropertyImage_Property_IdProperty] FOREIGN KEY ([IdProperty]) REFERENCES [Property] ([IdProperty]) ON DELETE CASCADE
);
GO

CREATE TABLE [PropertyTrace] (
    [IdPropertyTrace] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [NameClient] nvarchar(250) NOT NULL,
    [Value] float(28) NOT NULL,
    [Tax] decimal(10,2) NOT NULL,
    [IdProperty] int NOT NULL,
    CONSTRAINT [PK_PropertyTrace] PRIMARY KEY ([IdPropertyTrace]),
    CONSTRAINT [FK_PropertyTrace_Property_IdProperty] FOREIGN KEY ([IdProperty]) REFERENCES [Property] ([IdProperty]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Property_IdOwner] ON [Property] ([IdOwner]);
GO

CREATE INDEX [IX_PropertyImage_IdProperty] ON [PropertyImage] ([IdProperty]);
GO

CREATE INDEX [IX_PropertyTrace_IdProperty] ON [PropertyTrace] ([IdProperty]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240108020738_initialMigration', N'6.0.25');
GO

COMMIT;
GO