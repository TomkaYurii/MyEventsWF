CREATE TABLE [dbo].[Countries] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [name]    NVARCHAR (50) NOT NULL,
    [city_id] INT           NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Countries__city___75A278F5] FOREIGN KEY ([city_id]) REFERENCES [dbo].[Cities] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Countries_city_id]
    ON [dbo].[Countries]([city_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Countrie__72E12F1B0A12FB18]
    ON [dbo].[Countries]([name] ASC);

