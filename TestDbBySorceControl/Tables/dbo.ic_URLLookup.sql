CREATE TABLE [dbo].[ic_URLLookup]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_URLLookup_Id] DEFAULT (newid()),
[FullUrl] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MenuId] [int] NOT NULL,
[ModuleInstanceId] [int] NULL,
[ItemId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ItemType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RoutingEntryId] [int] NULL,
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_URLLookup_IsDeleted] DEFAULT ((0)),
[NewUrlId] [uniqueidentifier] NULL,
[ViewsCount] [int] NOT NULL CONSTRAINT [DF_ic_URLLookup_ViewsCount] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_URLLookup] ADD CONSTRAINT [PK_ic_URLLookup] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_URLLookup_1] ON [dbo].[ic_URLLookup] ([FullUrl], [ItemId], [ViewsCount]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_UrlLookup_2] ON [dbo].[ic_URLLookup] ([IsDeleted]) INCLUDE ([FullUrl], [ItemId], [ItemType], [ViewsCount]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ItemType] ON [dbo].[ic_URLLookup] ([ItemType], [IsDeleted]) INCLUDE ([FullUrl], [ItemId], [MenuId], [ViewsCount]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_URLLookup] ADD CONSTRAINT [FK_ic_URLLookup_ic_Menus] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[ic_Menus] ([Id])
GO
ALTER TABLE [dbo].[ic_URLLookup] ADD CONSTRAINT [FK_ic_URLLookup_ic_ModuleInstances] FOREIGN KEY ([ModuleInstanceId]) REFERENCES [dbo].[ic_ModuleInstances] ([Id])
GO
ALTER TABLE [dbo].[ic_URLLookup] ADD CONSTRAINT [FK_ic_URLLookup_ic_RoutingEntries] FOREIGN KEY ([RoutingEntryId]) REFERENCES [dbo].[ic_RoutingEntries] ([Id])
GO
