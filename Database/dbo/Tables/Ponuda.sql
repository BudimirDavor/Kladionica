CREATE TABLE [dbo].[Ponuda] (
    [PonudaId]   BIGINT     IDENTITY (1, 1) NOT NULL,
    [SusretId]   BIGINT     NOT NULL,
    [Tip]        CHAR (1)   NOT NULL,
    [Koeficient] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_Ponuda] PRIMARY KEY CLUSTERED ([PonudaId] ASC),
    CONSTRAINT [FK_Ponuda_Susret] FOREIGN KEY ([SusretId]) REFERENCES [dbo].[Susret] ([SusretId]),
    CONSTRAINT [IX_Ponuda] UNIQUE NONCLUSTERED ([SusretId] ASC, [Tip] ASC)
);

