
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/17/2017 23:29:35
-- Generated from EDMX file: C:\SVN\POS\POS.Data\ModelSem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [POS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bill_2_PriceLis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_Bill_2_PriceLis];
GO
IF OBJECT_ID(N'[dbo].[FK_Bill_CretedByUser_2_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bill] DROP CONSTRAINT [FK_Bill_CretedByUser_2_User];
GO
IF OBJECT_ID(N'[dbo].[FK_BillItem_2_Bill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillItem] DROP CONSTRAINT [FK_BillItem_2_Bill];
GO
IF OBJECT_ID(N'[dbo].[FK_BillItem_CretedBy_2_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillItem] DROP CONSTRAINT [FK_BillItem_CretedBy_2_User];
GO
IF OBJECT_ID(N'[dbo].[FK_BillItem_MenuItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillItem] DROP CONSTRAINT [FK_BillItem_MenuItem];
GO
IF OBJECT_ID(N'[dbo].[FK_BillItem_ModifirdBy_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BillItem] DROP CONSTRAINT [FK_BillItem_ModifirdBy_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Check_2_PriceLis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Check] DROP CONSTRAINT [FK_Check_2_PriceLis];
GO
IF OBJECT_ID(N'[dbo].[FK_Check_CreatedBy_2_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Check] DROP CONSTRAINT [FK_Check_CreatedBy_2_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Division_Id_2_MenuItem_DivisionId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuItem] DROP CONSTRAINT [FK_Division_Id_2_MenuItem_DivisionId];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuGroup_Id_2_MenuGroup_Parent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuGroup] DROP CONSTRAINT [FK_MenuGroup_Id_2_MenuGroup_Parent];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuGroup_Id_2_MenuItem_MenuGroupId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuItem] DROP CONSTRAINT [FK_MenuGroup_Id_2_MenuItem_MenuGroupId];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuItem_Id_2_Price_MenuItemId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Price] DROP CONSTRAINT [FK_MenuItem_Id_2_Price_MenuItemId];
GO
IF OBJECT_ID(N'[dbo].[FK_PriceList_Id_2_Price_PriceListId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Price] DROP CONSTRAINT [FK_PriceList_Id_2_Price_PriceListId];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Id_2_MenuItem_UserCreatedId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuItem] DROP CONSTRAINT [FK_User_Id_2_MenuItem_UserCreatedId];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroup_Id_2_User_UserGroupId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_UserGroup_Id_2_User_UserGroupId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bill];
GO
IF OBJECT_ID(N'[dbo].[BillItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BillItem];
GO
IF OBJECT_ID(N'[dbo].[Check]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Check];
GO
IF OBJECT_ID(N'[dbo].[Division]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Division];
GO
IF OBJECT_ID(N'[dbo].[MenuGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuGroup];
GO
IF OBJECT_ID(N'[dbo].[MenuItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuItem];
GO
IF OBJECT_ID(N'[dbo].[Option]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Option];
GO
IF OBJECT_ID(N'[dbo].[Price]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Price];
GO
IF OBJECT_ID(N'[dbo].[PriceList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PriceList];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [Id] uniqueidentifier  NOT NULL,
    [CreatedTime] datetime  NOT NULL,
    [CreatedByUserId] uniqueidentifier  NOT NULL,
    [BillNumber] int  NOT NULL,
    [PriceListId] uniqueidentifier  NOT NULL,
    [Total] decimal(19,4)  NOT NULL,
    [Guests] int  NOT NULL,
    [Printered] bit  NOT NULL
);
GO

-- Creating table 'BillItems'
CREATE TABLE [dbo].[BillItems] (
    [Id] uniqueidentifier  NOT NULL,
    [CreatedTime] datetime  NOT NULL,
    [CreatedByUser] uniqueidentifier  NOT NULL,
    [BillId] uniqueidentifier  NOT NULL,
    [MenuItemId] uniqueidentifier  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [ModifiedTime] datetime  NULL,
    [ModifiedByUser] uniqueidentifier  NULL
);
GO

-- Creating table 'Checks'
CREATE TABLE [dbo].[Checks] (
    [Id] uniqueidentifier  NOT NULL,
    [CreatedTime] datetime  NOT NULL,
    [CreatedByUserId] uniqueidentifier  NOT NULL,
    [BillNumber] int  NOT NULL,
    [PriceListId] uniqueidentifier  NOT NULL,
    [Total] decimal(19,4)  NOT NULL,
    [Guests] int  NOT NULL,
    [Printered] bit  NOT NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Printer] nvarchar(50)  NULL,
    [Hidden] bit  NOT NULL
);
GO

-- Creating table 'MenuGroups'
CREATE TABLE [dbo].[MenuGroups] (
    [Id] uniqueidentifier  NOT NULL,
    [Parent] uniqueidentifier  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Order] int  NOT NULL,
    [Hidden] bit  NOT NULL
);
GO

-- Creating table 'MenuItems'
CREATE TABLE [dbo].[MenuItems] (
    [Id] uniqueidentifier  NOT NULL,
    [MenuGroupId] uniqueidentifier  NULL,
    [DivisionId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Code] int  NULL,
    [BarCode] nvarchar(13)  NULL,
    [Image] nvarchar(50)  NULL,
    [UserCreatedId] uniqueidentifier  NOT NULL,
    [Hidden] bit  NOT NULL
);
GO

-- Creating table 'Options'
CREATE TABLE [dbo].[Options] (
    [Id] nvarchar(50)  NOT NULL,
    [Value] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] uniqueidentifier  NOT NULL,
    [PriceListId] uniqueidentifier  NOT NULL,
    [MenuItemId] uniqueidentifier  NOT NULL,
    [Price1] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'PriceLists'
CREATE TABLE [dbo].[PriceLists] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [UserGroupId] uniqueidentifier  NOT NULL,
    [Code] int  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Card] nvarchar(20)  NULL,
    [SexMale] bit  NOT NULL,
    [Hidden] bit  NOT NULL
);
GO

-- Creating table 'UserGroups'
CREATE TABLE [dbo].[UserGroups] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BillItems'
ALTER TABLE [dbo].[BillItems]
ADD CONSTRAINT [PK_BillItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [PK_Checks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuGroups'
ALTER TABLE [dbo].[MenuGroups]
ADD CONSTRAINT [PK_MenuGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [PK_MenuItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Options'
ALTER TABLE [dbo].[Options]
ADD CONSTRAINT [PK_Options]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PriceLists'
ALTER TABLE [dbo].[PriceLists]
ADD CONSTRAINT [PK_PriceLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserGroups'
ALTER TABLE [dbo].[UserGroups]
ADD CONSTRAINT [PK_UserGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PriceListId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_Bill_2_PriceLis]
    FOREIGN KEY ([PriceListId])
    REFERENCES [dbo].[PriceLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bill_2_PriceLis'
CREATE INDEX [IX_FK_Bill_2_PriceLis]
ON [dbo].[Bills]
    ([PriceListId]);
GO

-- Creating foreign key on [CreatedByUserId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_Bill_CretedByUser_2_User]
    FOREIGN KEY ([CreatedByUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bill_CretedByUser_2_User'
CREATE INDEX [IX_FK_Bill_CretedByUser_2_User]
ON [dbo].[Bills]
    ([CreatedByUserId]);
GO

-- Creating foreign key on [BillId] in table 'BillItems'
ALTER TABLE [dbo].[BillItems]
ADD CONSTRAINT [FK_BillItem_2_Bill]
    FOREIGN KEY ([BillId])
    REFERENCES [dbo].[Bills]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillItem_2_Bill'
CREATE INDEX [IX_FK_BillItem_2_Bill]
ON [dbo].[BillItems]
    ([BillId]);
GO

-- Creating foreign key on [CreatedByUser] in table 'BillItems'
ALTER TABLE [dbo].[BillItems]
ADD CONSTRAINT [FK_BillItem_CretedBy_2_User]
    FOREIGN KEY ([CreatedByUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillItem_CretedBy_2_User'
CREATE INDEX [IX_FK_BillItem_CretedBy_2_User]
ON [dbo].[BillItems]
    ([CreatedByUser]);
GO

-- Creating foreign key on [MenuItemId] in table 'BillItems'
ALTER TABLE [dbo].[BillItems]
ADD CONSTRAINT [FK_BillItem_MenuItem]
    FOREIGN KEY ([MenuItemId])
    REFERENCES [dbo].[MenuItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillItem_MenuItem'
CREATE INDEX [IX_FK_BillItem_MenuItem]
ON [dbo].[BillItems]
    ([MenuItemId]);
GO

-- Creating foreign key on [ModifiedByUser] in table 'BillItems'
ALTER TABLE [dbo].[BillItems]
ADD CONSTRAINT [FK_BillItem_ModifirdBy_User]
    FOREIGN KEY ([ModifiedByUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillItem_ModifirdBy_User'
CREATE INDEX [IX_FK_BillItem_ModifirdBy_User]
ON [dbo].[BillItems]
    ([ModifiedByUser]);
GO

-- Creating foreign key on [PriceListId] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_Check_2_PriceLis]
    FOREIGN KEY ([PriceListId])
    REFERENCES [dbo].[PriceLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Check_2_PriceLis'
CREATE INDEX [IX_FK_Check_2_PriceLis]
ON [dbo].[Checks]
    ([PriceListId]);
GO

-- Creating foreign key on [CreatedByUserId] in table 'Checks'
ALTER TABLE [dbo].[Checks]
ADD CONSTRAINT [FK_Check_CreatedBy_2_User]
    FOREIGN KEY ([CreatedByUserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Check_CreatedBy_2_User'
CREATE INDEX [IX_FK_Check_CreatedBy_2_User]
ON [dbo].[Checks]
    ([CreatedByUserId]);
GO

-- Creating foreign key on [DivisionId] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [FK_Division_Id_2_MenuItem_DivisionId]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Division_Id_2_MenuItem_DivisionId'
CREATE INDEX [IX_FK_Division_Id_2_MenuItem_DivisionId]
ON [dbo].[MenuItems]
    ([DivisionId]);
GO

-- Creating foreign key on [Parent] in table 'MenuGroups'
ALTER TABLE [dbo].[MenuGroups]
ADD CONSTRAINT [FK_MenuGroup_Id_2_MenuGroup_Parent]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[MenuGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuGroup_Id_2_MenuGroup_Parent'
CREATE INDEX [IX_FK_MenuGroup_Id_2_MenuGroup_Parent]
ON [dbo].[MenuGroups]
    ([Parent]);
GO

-- Creating foreign key on [MenuGroupId] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [FK_MenuGroup_Id_2_MenuItem_MenuGroupId]
    FOREIGN KEY ([MenuGroupId])
    REFERENCES [dbo].[MenuGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuGroup_Id_2_MenuItem_MenuGroupId'
CREATE INDEX [IX_FK_MenuGroup_Id_2_MenuItem_MenuGroupId]
ON [dbo].[MenuItems]
    ([MenuGroupId]);
GO

-- Creating foreign key on [MenuItemId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_MenuItem_Id_2_Price_MenuItemId]
    FOREIGN KEY ([MenuItemId])
    REFERENCES [dbo].[MenuItems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuItem_Id_2_Price_MenuItemId'
CREATE INDEX [IX_FK_MenuItem_Id_2_Price_MenuItemId]
ON [dbo].[Prices]
    ([MenuItemId]);
GO

-- Creating foreign key on [UserCreatedId] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [FK_User_Id_2_MenuItem_UserCreatedId]
    FOREIGN KEY ([UserCreatedId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Id_2_MenuItem_UserCreatedId'
CREATE INDEX [IX_FK_User_Id_2_MenuItem_UserCreatedId]
ON [dbo].[MenuItems]
    ([UserCreatedId]);
GO

-- Creating foreign key on [PriceListId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_PriceList_Id_2_Price_PriceListId]
    FOREIGN KEY ([PriceListId])
    REFERENCES [dbo].[PriceLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PriceList_Id_2_Price_PriceListId'
CREATE INDEX [IX_FK_PriceList_Id_2_Price_PriceListId]
ON [dbo].[Prices]
    ([PriceListId]);
GO

-- Creating foreign key on [UserGroupId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserGroup_Id_2_User_UserGroupId]
    FOREIGN KEY ([UserGroupId])
    REFERENCES [dbo].[UserGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroup_Id_2_User_UserGroupId'
CREATE INDEX [IX_FK_UserGroup_Id_2_User_UserGroupId]
ON [dbo].[Users]
    ([UserGroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------