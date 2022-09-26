CREATE TABLE [dbo].[Messages] (
    [id]       INT            IDENTITY (1, 1) NOT NULL,
    [user_id]  INT            NULL,
    [event_id] INT            NULL,
    [message]  NVARCHAR (500) NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__Messages__enent___7F2BE32F] FOREIGN KEY ([event_id]) REFERENCES [dbo].[Events] ([id]),
    CONSTRAINT [FK__Messages__user_i__00200768] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_event_id]
    ON [dbo].[Messages]([event_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_user_id]
    ON [dbo].[Messages]([user_id] ASC);

