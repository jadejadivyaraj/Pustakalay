
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/16/2012 22:13:09
-- Generated from EDMX file: E:\Pustakalay\src\Business\Pustakalay.Data\PustakalayModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Pustakalay];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookInfoBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookInfoBook];
GO
IF OBJECT_ID(N'[dbo].[FK_Books_Purchases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_Purchases];
GO
IF OBJECT_ID(N'[PustakalayModelStoreContainer].[FK_PurchaseDetails_Books]', 'F') IS NOT NULL
    ALTER TABLE [PustakalayModelStoreContainer].[PurchaseDetails] DROP CONSTRAINT [FK_PurchaseDetails_Books];
GO
IF OBJECT_ID(N'[PustakalayModelStoreContainer].[FK_PurchaseDetails_Purchases]', 'F') IS NOT NULL
    ALTER TABLE [PustakalayModelStoreContainer].[PurchaseDetails] DROP CONSTRAINT [FK_PurchaseDetails_Purchases];
GO
IF OBJECT_ID(N'[PustakalayModelStoreContainer].[FK_PurchaseDetails_Suppliers]', 'F') IS NOT NULL
    ALTER TABLE [PustakalayModelStoreContainer].[PurchaseDetails] DROP CONSTRAINT [FK_PurchaseDetails_Suppliers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BookInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookInfoes];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[PustakalayModelStoreContainer].[PurchaseDetails]', 'U') IS NOT NULL
    DROP TABLE [PustakalayModelStoreContainer].[PurchaseDetails];
GO
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookInfoes'
CREATE TABLE [dbo].[BookInfoes] (
    [Isbn] nchar(13)  NOT NULL,
    [Title] varchar(150)  NOT NULL,
    [Author] varchar(150)  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] uniqueidentifier  NOT NULL,
    [Isbn] nchar(13)  NULL,
    [PurchaseId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PurchaseDetails'
CREATE TABLE [dbo].[PurchaseDetails] (
    [Id] uniqueidentifier  NOT NULL,
    [BookId] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] uniqueidentifier  NOT NULL,
    [SupplierId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Isbn] in table 'BookInfoes'
ALTER TABLE [dbo].[BookInfoes]
ADD CONSTRAINT [PK_BookInfoes]
    PRIMARY KEY CLUSTERED ([Isbn] ASC);
GO

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [BookId], [SupplierId] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [PK_PurchaseDetails]
    PRIMARY KEY CLUSTERED ([Id], [BookId], [SupplierId] ASC);
GO

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Isbn] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookInfoBook]
    FOREIGN KEY ([Isbn])
    REFERENCES [dbo].[BookInfoes]
        ([Isbn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookInfoBook'
CREATE INDEX [IX_FK_BookInfoBook]
ON [dbo].[Books]
    ([Isbn]);
GO

-- Creating foreign key on [PurchaseId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Books_Purchases]
    FOREIGN KEY ([PurchaseId])
    REFERENCES [dbo].[Purchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Books_Purchases'
CREATE INDEX [IX_FK_Books_Purchases]
ON [dbo].[Books]
    ([PurchaseId]);
GO

-- Creating foreign key on [BookId] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [FK_PurchaseDetails_Books]
    FOREIGN KEY ([BookId])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseDetails_Books'
CREATE INDEX [IX_FK_PurchaseDetails_Books]
ON [dbo].[PurchaseDetails]
    ([BookId]);
GO

-- Creating foreign key on [Id] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [FK_PurchaseDetails_Purchases]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Purchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SupplierId] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [FK_PurchaseDetails_Suppliers]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[Suppliers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseDetails_Suppliers'
CREATE INDEX [IX_FK_PurchaseDetails_Suppliers]
ON [dbo].[PurchaseDetails]
    ([SupplierId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------