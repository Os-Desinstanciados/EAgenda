CREATE TABLE [dbo].[TBCompromisso] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Assunto]         NVARCHAR (100)   NOT NULL,
    [DataOcorrencia]  DATE             NOT NULL,
    [HoraInicio]      TIME (7)         NOT NULL,
    [HoraTermino]     TIME (7)         NOT NULL,
    [TipoCompromisso] NVARCHAR (20)    NOT NULL,
    [Local]           NVARCHAR (200)   NULL,
    [Link]            NVARCHAR (300)   NULL,
    [ContatoId]       UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

ALTER TABLE [dbo].[TBCompromisso]
    ADD CONSTRAINT [FK_TBCompromisso_TBContato] FOREIGN KEY ([ContatoId]) REFERENCES [dbo].[TBContato] ([Id]);
GO

