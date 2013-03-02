
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/07/2013 00:13:24
-- Generated from EDMX file: D:\VS2012 Projects\Pustakalay\src\Business\Pustakalay.Data\PustakalayModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Pust];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookBookInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookBookInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchasePurchaseItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_PurchasePurchaseItems];
GO
IF OBJECT_ID(N'[dbo].[FK_BookPurchaseItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookPurchaseItems];
GO
IF OBJECT_ID(N'[dbo].[FK_BookInfoAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookInfoes] DROP CONSTRAINT [FK_BookInfoAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_BookInfoPublisher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookInfoes] DROP CONSTRAINT [FK_BookInfoPublisher];
GO
IF OBJECT_ID(N'[dbo].[FK_BookLend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_BookLend];
GO
IF OBJECT_ID(N'[dbo].[FK_LendMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lends] DROP CONSTRAINT [FK_LendMember];
GO
IF OBJECT_ID(N'[dbo].[FK_RentalLend_inherits_Lend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lends_RentalLend] DROP CONSTRAINT [FK_RentalLend_inherits_Lend];
GO
IF OBJECT_ID(N'[dbo].[FK_NonRentalLend_inherits_Lend]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lends_NonRentalLend] DROP CONSTRAINT [FK_NonRentalLend_inherits_Lend];
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
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[PurchaseItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseItems];
GO
IF OBJECT_ID(N'[dbo].[Authors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authors];
GO
IF OBJECT_ID(N'[dbo].[Publishers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publishers];
GO
IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[Lends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lends];
GO
IF OBJECT_ID(N'[dbo].[Lends_RentalLend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lends_RentalLend];
GO
IF OBJECT_ID(N'[dbo].[Lends_NonRentalLend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lends_NonRentalLend];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookInfoes'
CREATE TABLE [dbo].[BookInfoes] (
    [Title] varchar(150)  NOT NULL,
    [Isbn] bigint  NOT NULL,
    [AuthorId] int  NOT NULL,
    [PublisherId] int  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] uniqueidentifier  NOT NULL,
    [Isbn] bigint  NULL,
    [Price] int  NOT NULL,
    [Earning] int  NOT NULL,
    [LendId] uniqueidentifier  NULL,
    [PurchaseCost] int  NOT NULL,
    [PurchaseItem_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [PurchaseItems_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PurchaseItems'
CREATE TABLE [dbo].[PurchaseItems] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Authors'
CREATE TABLE [dbo].[Authors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(150)  NOT NULL,
    [LastName] varchar(150)  NOT NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(150)  NOT NULL
);
GO

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] varchar(150)  NOT NULL,
    [LastName] varchar(150)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Address_AddLine1] varchar(200)  NOT NULL,
    [Address_AddLine2] varchar(200)  NOT NULL,
    [Address_City] varchar(50)  NOT NULL,
    [Address_Pincode] char(6)  NOT NULL
);
GO

-- Creating table 'Lends'
CREATE TABLE [dbo].[Lends] (
    [Id] uniqueidentifier  NOT NULL,
    [MemberId] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'Lends_RentalLend'
CREATE TABLE [dbo].[Lends_RentalLend] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Lends_NonRentalLend'
CREATE TABLE [dbo].[Lends_NonRentalLend] (
    [DepositAmount] int  NOT NULL,
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

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchaseItems'
ALTER TABLE [dbo].[PurchaseItems]
ADD CONSTRAINT [PK_PurchaseItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Authors'
ALTER TABLE [dbo].[Authors]
ADD CONSTRAINT [PK_Authors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lends'
ALTER TABLE [dbo].[Lends]
ADD CONSTRAINT [PK_Lends]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lends_RentalLend'
ALTER TABLE [dbo].[Lends_RentalLend]
ADD CONSTRAINT [PK_Lends_RentalLend]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lends_NonRentalLend'
ALTER TABLE [dbo].[Lends_NonRentalLend]
ADD CONSTRAINT [PK_Lends_NonRentalLend]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Isbn] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookBookInfo]
    FOREIGN KEY ([Isbn])
    REFERENCES [dbo].[BookInfoes]
        ([Isbn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookBookInfo'
CREATE INDEX [IX_FK_BookBookInfo]
ON [dbo].[Books]
    ([Isbn]);
GO

-- Creating foreign key on [PurchaseItems_Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_PurchasePurchaseItems]
    FOREIGN KEY ([PurchaseItems_Id])
    REFERENCES [dbo].[PurchaseItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchasePurchaseItems'
CREATE INDEX [IX_FK_PurchasePurchaseItems]
ON [dbo].[Purchases]
    ([PurchaseItems_Id]);
GO

-- Creating foreign key on [PurchaseItem_Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookPurchaseItems]
    FOREIGN KEY ([PurchaseItem_Id])
    REFERENCES [dbo].[PurchaseItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookPurchaseItems'
CREATE INDEX [IX_FK_BookPurchaseItems]
ON [dbo].[Books]
    ([PurchaseItem_Id]);
GO

-- Creating foreign key on [AuthorId] in table 'BookInfoes'
ALTER TABLE [dbo].[BookInfoes]
ADD CONSTRAINT [FK_BookInfoAuthor]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[Authors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookInfoAuthor'
CREATE INDEX [IX_FK_BookInfoAuthor]
ON [dbo].[BookInfoes]
    ([AuthorId]);
GO

-- Creating foreign key on [PublisherId] in table 'BookInfoes'
ALTER TABLE [dbo].[BookInfoes]
ADD CONSTRAINT [FK_BookInfoPublisher]
    FOREIGN KEY ([PublisherId])
    REFERENCES [dbo].[Publishers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookInfoPublisher'
CREATE INDEX [IX_FK_BookInfoPublisher]
ON [dbo].[BookInfoes]
    ([PublisherId]);
GO

-- Creating foreign key on [LendId] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_BookLend]
    FOREIGN KEY ([LendId])
    REFERENCES [dbo].[Lends]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookLend'
CREATE INDEX [IX_FK_BookLend]
ON [dbo].[Books]
    ([LendId]);
GO

-- Creating foreign key on [MemberId] in table 'Lends'
ALTER TABLE [dbo].[Lends]
ADD CONSTRAINT [FK_LendMember]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LendMember'
CREATE INDEX [IX_FK_LendMember]
ON [dbo].[Lends]
    ([MemberId]);
GO

-- Creating foreign key on [Id] in table 'Lends_RentalLend'
ALTER TABLE [dbo].[Lends_RentalLend]
ADD CONSTRAINT [FK_RentalLend_inherits_Lend]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Lends]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Lends_NonRentalLend'
ALTER TABLE [dbo].[Lends_NonRentalLend]
ADD CONSTRAINT [FK_NonRentalLend_inherits_Lend]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Lends]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------