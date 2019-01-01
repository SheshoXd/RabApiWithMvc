CREATE TABLE [dbo].[ic_Templates]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Version] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Author] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AuthorUrl] [varchar] (120) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ThumbnailUrl] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Path] [varchar] (120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsAdmin] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_Templates_IsDeleted] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Templates] ADD CONSTRAINT [PK_ic_Templates] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
