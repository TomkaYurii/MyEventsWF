CREATE TABLE [dbo].[Users] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [first_name]  NVARCHAR (50) NOT NULL,
    [second_name] NVARCHAR (50) NOT NULL,
    [email]       NVARCHAR (50) NOT NULL,
    [password]    NVARCHAR (50) NOT NULL,
    [role_id]     INT           NOT NULL,
    [country_id]  INT           NULL,
    [city_id]     INT           NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Users__city_id__778AC167] FOREIGN KEY ([city_id]) REFERENCES [dbo].[Cities] ([id]),
    CONSTRAINT [FK__Users__country_i__76969D2E] FOREIGN KEY ([country_id]) REFERENCES [dbo].[Countries] ([id]),
    CONSTRAINT [FK__Users__role_id__7E37BEF6] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Roles] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_city_id]
    ON [dbo].[Users]([city_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Users_country_id]
    ON [dbo].[Users]([country_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Users__760965CD1BC080B4]
    ON [dbo].[Users]([role_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Users__AB6E6164C19E76E7]
    ON [dbo].[Users]([email] ASC);

