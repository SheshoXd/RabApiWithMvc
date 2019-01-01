CREATE TABLE [dbo].[ic_Categories]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ic_Categories_Type] DEFAULT ('C'),
[ParentId] [int] NOT NULL,
[Sublevel] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[Slug] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[ImageId] [int] NULL,
[CssClass] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Ordering] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Categories] ADD CONSTRAINT [PK_ic_Categories] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
