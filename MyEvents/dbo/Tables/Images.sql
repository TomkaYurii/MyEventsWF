CREATE TABLE [dbo].[Images] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (300) NOT NULL,
    [gallery_id] INT            NULL,
    [user_id]    INT            NULL,
    [ImageBytes] IMAGE          NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Images__gallery___7C4F7684] FOREIGN KEY ([gallery_id]) REFERENCES [dbo].[Galleries] ([id]),
    CONSTRAINT [FK__Images__user_id__7D439ABD] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Images_gallery_id]
    ON [dbo].[Images]([gallery_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Images_user_id]
    ON [dbo].[Images]([user_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Images__72E12F1B116F28F5]
    ON [dbo].[Images]([name] ASC);

