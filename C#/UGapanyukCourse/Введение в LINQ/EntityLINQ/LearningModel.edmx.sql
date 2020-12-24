
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2020 03:22:26
-- Generated from EDMX file: D:\root\yura\institute\УЧЕБНО_МЕТОДИЧЕСКИЕ\!_КУРСЫ\БКИТ\linq_2020\SimpleLINQ_VS2019\EntityLINQ\LearningModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [learning];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SubjectSubjectType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectSet] DROP CONSTRAINT [FK_SubjectSubjectType];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentGroupSubject_StudentGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentGroupSubject] DROP CONSTRAINT [FK_StudentGroupSubject_StudentGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentGroupSubject_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentGroupSubject] DROP CONSTRAINT [FK_StudentGroupSubject_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectTypeSubjectType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectTypeSet] DROP CONSTRAINT [FK_SubjectTypeSubjectType];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentGroupSpecial_inherits_StudentGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentGroupSet_StudentGroupSpecial] DROP CONSTRAINT [FK_StudentGroupSpecial_inherits_StudentGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentGroupSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentGroupSet];
GO
IF OBJECT_ID(N'[dbo].[SubjectTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectTypeSet];
GO
IF OBJECT_ID(N'[dbo].[SubjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectSet];
GO
IF OBJECT_ID(N'[dbo].[StudentGroupSet_StudentGroupSpecial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentGroupSet_StudentGroupSpecial];
GO
IF OBJECT_ID(N'[dbo].[StudentGroupSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentGroupSubject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentGroupSet'
CREATE TABLE [dbo].[StudentGroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SubjectTypeSet'
CREATE TABLE [dbo].[SubjectTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [SubjectTypeId] int  NULL
);
GO

-- Creating table 'SubjectSet'
CREATE TABLE [dbo].[SubjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubjectName] nvarchar(max)  NOT NULL,
    [Value] int  NOT NULL,
    [SubjectType_Id] int  NOT NULL
);
GO

-- Creating table 'StudentGroupSet_StudentGroupSpecial'
CREATE TABLE [dbo].[StudentGroupSet_StudentGroupSpecial] (
    [Flag] bit  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'StudentGroupSubject'
CREATE TABLE [dbo].[StudentGroupSubject] (
    [StudentGroup_Id] int  NOT NULL,
    [Subject_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentGroupSet'
ALTER TABLE [dbo].[StudentGroupSet]
ADD CONSTRAINT [PK_StudentGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectTypeSet'
ALTER TABLE [dbo].[SubjectTypeSet]
ADD CONSTRAINT [PK_SubjectTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectSet'
ALTER TABLE [dbo].[SubjectSet]
ADD CONSTRAINT [PK_SubjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentGroupSet_StudentGroupSpecial'
ALTER TABLE [dbo].[StudentGroupSet_StudentGroupSpecial]
ADD CONSTRAINT [PK_StudentGroupSet_StudentGroupSpecial]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StudentGroup_Id], [Subject_Id] in table 'StudentGroupSubject'
ALTER TABLE [dbo].[StudentGroupSubject]
ADD CONSTRAINT [PK_StudentGroupSubject]
    PRIMARY KEY CLUSTERED ([StudentGroup_Id], [Subject_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SubjectType_Id] in table 'SubjectSet'
ALTER TABLE [dbo].[SubjectSet]
ADD CONSTRAINT [FK_SubjectSubjectType]
    FOREIGN KEY ([SubjectType_Id])
    REFERENCES [dbo].[SubjectTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectSubjectType'
CREATE INDEX [IX_FK_SubjectSubjectType]
ON [dbo].[SubjectSet]
    ([SubjectType_Id]);
GO

-- Creating foreign key on [StudentGroup_Id] in table 'StudentGroupSubject'
ALTER TABLE [dbo].[StudentGroupSubject]
ADD CONSTRAINT [FK_StudentGroupSubject_StudentGroup]
    FOREIGN KEY ([StudentGroup_Id])
    REFERENCES [dbo].[StudentGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subject_Id] in table 'StudentGroupSubject'
ALTER TABLE [dbo].[StudentGroupSubject]
ADD CONSTRAINT [FK_StudentGroupSubject_Subject]
    FOREIGN KEY ([Subject_Id])
    REFERENCES [dbo].[SubjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentGroupSubject_Subject'
CREATE INDEX [IX_FK_StudentGroupSubject_Subject]
ON [dbo].[StudentGroupSubject]
    ([Subject_Id]);
GO

-- Creating foreign key on [SubjectTypeId] in table 'SubjectTypeSet'
ALTER TABLE [dbo].[SubjectTypeSet]
ADD CONSTRAINT [FK_SubjectTypeSubjectType]
    FOREIGN KEY ([SubjectTypeId])
    REFERENCES [dbo].[SubjectTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectTypeSubjectType'
CREATE INDEX [IX_FK_SubjectTypeSubjectType]
ON [dbo].[SubjectTypeSet]
    ([SubjectTypeId]);
GO

-- Creating foreign key on [Id] in table 'StudentGroupSet_StudentGroupSpecial'
ALTER TABLE [dbo].[StudentGroupSet_StudentGroupSpecial]
ADD CONSTRAINT [FK_StudentGroupSpecial_inherits_StudentGroup]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[StudentGroupSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------