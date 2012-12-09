
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2012 14:36:37
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

IF OBJECT_ID(N'[dbo].[FK_Books_BookInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_BookInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BookInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookInfo];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
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
    [Isbn] nchar(13)  NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Isbn] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_Books_BookInfo]
    FOREIGN KEY ([Isbn])
    REFERENCES [dbo].[BookInfoes]
        ([Isbn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Books_BookInfo'
CREATE INDEX [IX_FK_Books_BookInfo]
ON [dbo].[Books]
    ([Isbn]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------