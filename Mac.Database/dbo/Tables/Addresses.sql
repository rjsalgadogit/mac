CREATE TABLE [dbo].[Addresses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Address]     NVARCHAR (12)  NULL,
    [Description] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

