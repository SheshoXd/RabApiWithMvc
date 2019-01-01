CREATE TABLE [dbo].[ic_Contents]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[CategoryId] [int] NULL,
[ItemType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ic_Contents_ItemType] DEFAULT ('C'),
[Title] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IntroText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FullText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ImageId] [int] NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL,
[IsPublished] [bit] NOT NULL CONSTRAINT [DF_ic_Contents_IsPublished] DEFAULT ((1)),
[IsDeleted] [bit] NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Contents] ADD CONSTRAINT [PK_ic_Contents] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ItemType] ON [dbo].[ic_Contents] ([ItemType]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Contents] ADD CONSTRAINT [FK_ic_Contents_ic_Assets] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
ALTER TABLE [dbo].[ic_Contents] ADD CONSTRAINT [FK_ic_Contents_ic_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ic_Categories] ([Id])
GO
