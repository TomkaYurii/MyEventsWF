CREATE TABLE [dbo].[Events] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (250) NOT NULL,
    [user_id]        INT            NULL,
    [country_id]     INT            NULL,
    [city_id]        INT            NULL,
    [gallery_id]     INT            NULL,
    [time_of_event]  TIME (7)       NULL,
    [date_of_event]  DATE           NULL,
    [address]        NCHAR (80)     NULL,
    [acceptable_age] INT            NULL,
    [cost_of_visit]  FLOAT (53)     NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Events__city_id__787EE5A0] FOREIGN KEY ([city_id]) REFERENCES [dbo].[Cities] ([id]),
    CONSTRAINT [FK__Events__country___797309D9] FOREIGN KEY ([country_id]) REFERENCES [dbo].[Countries] ([id]),
    CONSTRAINT [FK__Events__gallery___7B5B524B] FOREIGN KEY ([gallery_id]) REFERENCES [dbo].[Galleries] ([id]),
    CONSTRAINT [FK__Events__user_id__7A672E12] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Events_city_id]
    ON [dbo].[Events]([city_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Events_country_id]
    ON [dbo].[Events]([country_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Events_gallery_id]
    ON [dbo].[Events]([gallery_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Events_user_id]
    ON [dbo].[Events]([user_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Events__72E12F1BCB86E8B3]
    ON [dbo].[Events]([name] ASC);

