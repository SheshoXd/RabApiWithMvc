CREATE TABLE [dbo].[ic_ItemTags]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_ItemTags_Id] DEFAULT (newid()),
[RefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TagId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ItemTags] ADD CONSTRAINT [PK_ic_ItemTags] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ic_ItemTags] ON [dbo].[ic_ItemTags] ([RefId], [RefTable], [TagId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ItemTags] ADD CONSTRAINT [FK_ic_ItemTags_ic_Tags] FOREIGN KEY ([TagId]) REFERENCES [dbo].[ic_Tags] ([Id])
GO
