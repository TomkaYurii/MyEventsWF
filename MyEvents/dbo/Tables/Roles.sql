CREATE TABLE [dbo].[Roles] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Roles__72E12F1B4750934D]
    ON [dbo].[Roles]([name] ASC);

