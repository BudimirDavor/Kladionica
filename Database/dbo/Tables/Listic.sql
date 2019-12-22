CREATE TABLE [dbo].[Listic] (
    [ListicId]      BIGINT     IDENTITY (1, 1) NOT NULL,
    [VrijemeUplate] DATETIME   NOT NULL,
    [IznosUplate]   FLOAT (53) NOT NULL,
    [MoguciDobitak] FLOAT (53) NULL,
    [UpdateDate]    DATETIME   NULL,
    CONSTRAINT [PK_Listic] PRIMARY KEY CLUSTERED ([ListicId] ASC)
);

