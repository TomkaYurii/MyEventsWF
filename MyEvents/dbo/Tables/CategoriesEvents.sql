CREATE TABLE [dbo].[CategoriesEvents] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [category_id] INT NULL,
    [event_id]    INT NULL,
    CONSTRAINT [PK_CategoriesEvents] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Categorie__categ__02084FDA] FOREIGN KEY ([category_id]) REFERENCES [dbo].[Categories] ([id]),
    CONSTRAINT [FK__Categorie__event__01142BA1] FOREIGN KEY ([event_id]) REFERENCES [dbo].[Events] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CategoriesEvents_category_id]
    ON [dbo].[CategoriesEvents]([category_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoriesEvents_event_id]
    ON [dbo].[CategoriesEvents]([event_id] ASC);

