
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/02/2021 17:02:37
-- Generated from EDMX file: D:\ШАГ\ADO.net sql\dz\dz 6\ConsoleApp2\ConsoleApp2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [New_rent_dz_6];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RoomsInfo'
CREATE TABLE [dbo].[RoomsInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Area] nvarchar(50)  NOT NULL,
    [AccommodationAddress] nvarchar(50)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [StartRent] datetime  NOT NULL,
    [EndRent] datetime  NOT NULL,
    [UsersInfoId] int  NULL
);
GO

-- Creating table 'UsersInfo'
CREATE TABLE [dbo].[UsersInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RoomsInfo'
ALTER TABLE [dbo].[RoomsInfo]
ADD CONSTRAINT [PK_RoomsInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersInfo'
ALTER TABLE [dbo].[UsersInfo]
ADD CONSTRAINT [PK_UsersInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsersInfoId] in table 'RoomsInfo'
ALTER TABLE [dbo].[RoomsInfo]
ADD CONSTRAINT [FK_UsersInfoRoomsInfo]
    FOREIGN KEY ([UsersInfoId])
    REFERENCES [dbo].[UsersInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersInfoRoomsInfo'
CREATE INDEX [IX_FK_UsersInfoRoomsInfo]
ON [dbo].[RoomsInfo]
    ([UsersInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------