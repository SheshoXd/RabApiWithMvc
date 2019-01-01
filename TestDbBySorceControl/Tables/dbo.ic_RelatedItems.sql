CREATE TABLE [dbo].[ic_RelatedItems]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_RelatedItems_Id] DEFAULT (newid()),
[FirstItemId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FirstItemRefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SecondItemId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[SecondItemRefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_RelatedItems] ADD CONSTRAINT [PK_ic_RelatedImages] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_IsDeleted] ON [dbo].[ic_RelatedItems] ([IsDeleted]) INCLUDE ([FirstItemId], [FirstItemRefTable], [SecondItemId], [SecondItemRefTable]) ON [PRIMARY]
GO
