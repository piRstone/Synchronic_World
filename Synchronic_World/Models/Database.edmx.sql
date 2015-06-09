
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2015 22:45:47
-- Generated from EDMX file: D:\Documents\Visual Studio 2013\Projects\Synchronic World\Synchronic_World\Models\Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [synchronicDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserEvent_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvent] DROP CONSTRAINT [FK_UserEvent_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEvent_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvent] DROP CONSTRAINT [FK_UserEvent_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventContribution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContributionSet] DROP CONSTRAINT [FK_EventContribution];
GO
IF OBJECT_ID(N'[dbo].[FK_UserContribution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContributionSet] DROP CONSTRAINT [FK_UserContribution];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[EventSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventSet];
GO
IF OBJECT_ID(N'[dbo].[ContributionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContributionSet];
GO
IF OBJECT_ID(N'[dbo].[FriendsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FriendsSet];
GO
IF OBJECT_ID(N'[dbo].[UserEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserEvent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [birthday] datetime  NOT NULL,
    [mail] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [role] nvarchar(max)  NULL
);
GO

-- Creating table 'EventSet'
CREATE TABLE [dbo].[EventSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [desc] nvarchar(max)  NOT NULL,
    [adress] nvarchar(max)  NOT NULL,
    [date] datetime  NOT NULL,
    [hour] nvarchar(max)  NOT NULL,
    [type] int  NOT NULL,
    [status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContributionSet'
CREATE TABLE [dbo].[ContributionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [quantity] int  NOT NULL,
    [EventId] int  NOT NULL,
    [type] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'FriendsSet'
CREATE TABLE [dbo].[FriendsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userId] int  NOT NULL,
    [friendId] int  NOT NULL
);
GO

-- Creating table 'UserEvent'
CREATE TABLE [dbo].[UserEvent] (
    [participatingUser_Id] int  NOT NULL,
    [participatingEvent_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventSet'
ALTER TABLE [dbo].[EventSet]
ADD CONSTRAINT [PK_EventSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContributionSet'
ALTER TABLE [dbo].[ContributionSet]
ADD CONSTRAINT [PK_ContributionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FriendsSet'
ALTER TABLE [dbo].[FriendsSet]
ADD CONSTRAINT [PK_FriendsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [participatingUser_Id], [participatingEvent_Id] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [PK_UserEvent]
    PRIMARY KEY CLUSTERED ([participatingUser_Id], [participatingEvent_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [participatingUser_Id] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [FK_UserEvent_User]
    FOREIGN KEY ([participatingUser_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [participatingEvent_Id] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [FK_UserEvent_Event]
    FOREIGN KEY ([participatingEvent_Id])
    REFERENCES [dbo].[EventSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvent_Event'
CREATE INDEX [IX_FK_UserEvent_Event]
ON [dbo].[UserEvent]
    ([participatingEvent_Id]);
GO

-- Creating foreign key on [EventId] in table 'ContributionSet'
ALTER TABLE [dbo].[ContributionSet]
ADD CONSTRAINT [FK_EventContribution]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[EventSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventContribution'
CREATE INDEX [IX_FK_EventContribution]
ON [dbo].[ContributionSet]
    ([EventId]);
GO

-- Creating foreign key on [User_Id] in table 'ContributionSet'
ALTER TABLE [dbo].[ContributionSet]
ADD CONSTRAINT [FK_UserContribution]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserContribution'
CREATE INDEX [IX_FK_UserContribution]
ON [dbo].[ContributionSet]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------