CREATE TABLE [dbo].[Galleries] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Galleries] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Gallerie__72E12F1B67329A7C]
    ON [dbo].[Galleries]([name] ASC);

