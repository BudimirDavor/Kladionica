CREATE TABLE [dbo].[Oklada] (
    [OkladaId]   BIGINT     IDENTITY (1, 1) NOT NULL,
    [PonudaId]   BIGINT     NOT NULL,
    [ListicId]   BIGINT     NOT NULL,
    [Koeficient] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_Oklada] PRIMARY KEY CLUSTERED ([OkladaId] ASC),
    CONSTRAINT [FK_Oklada_Listic] FOREIGN KEY ([ListicId]) REFERENCES [dbo].[Listic] ([ListicId]),
    CONSTRAINT [FK_Oklada_Ponuda] FOREIGN KEY ([PonudaId]) REFERENCES [dbo].[Ponuda] ([PonudaId]),
    CONSTRAINT [IX_Oklada] UNIQUE NONCLUSTERED ([ListicId] ASC, [PonudaId] ASC)
);

