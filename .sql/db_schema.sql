IF DB_ID('EAgenda') IS NULL
BEGIN
    CREATE DATABASE [EAgenda];
END;

USE [EAgenda]
GO

CREATE TABLE [dbo].[TBContato] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Telefone] nvarchar(15) NOT NULL,
    [Cargo] nvarchar(100) NULL,
    [Empresa] nvarchar(100) NULL,
    PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[TBCompromisso] (
    [Id] uniqueidentifier NOT NULL,
    [Assunto] nvarchar(100) NOT NULL,
    [DataOcorrencia] date NOT NULL,
    [HoraInicio] time NOT NULL,
    [HoraTermino] time NOT NULL,
    [TipoCompromisso] nvarchar(20) NOT NULL,
    [Local] nvarchar(200) NULL,
    [Link] nvarchar(300) NULL,
    [ContatoId] uniqueidentifier NULL,
    PRIMARY KEY ([Id])
);

ALTER TABLE [dbo].[TBCompromisso]
ADD CONSTRAINT [FK_TBCompromisso_TBContato]
FOREIGN KEY ([ContatoId])
REFERENCES [dbo].[TBContato]([Id])
ON DELETE NO ACTION
ON UPDATE NO ACTION;