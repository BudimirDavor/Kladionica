CREATE TABLE [dbo].[Susret] (
    [SusretId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [Domacin]  VARCHAR (50) NOT NULL,
    [Gost]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Susret] PRIMARY KEY CLUSTERED ([SusretId] ASC)
);

