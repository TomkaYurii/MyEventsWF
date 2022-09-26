CREATE TABLE [dbo].[Categories] (
    [id]   INT IDENTITY (1, 1) NOT NULL,
    [name] INT NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Categori__72E12F1B6CA6E7A6]
    ON [dbo].[Categories]([name] ASC);

