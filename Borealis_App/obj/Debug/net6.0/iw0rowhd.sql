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

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208170931_AddUserstoDatabase', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [zapisi];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208231811_test', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [utrka] (
    [IDrecord] int NOT NULL IDENTITY,
    [Ime] nvarchar(max) NOT NULL,
    [Prezime] nvarchar(max) NOT NULL,
    [zavrsnovrijeme] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_utrka] PRIMARY KEY ([IDrecord])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208232545_AddUtrkaToDB', N'6.0.10');
GO

COMMIT;
GO

