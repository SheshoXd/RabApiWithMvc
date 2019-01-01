CREATE TABLE [dbo].[ic_Resources]
(
[ResourceCode] [char] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Media] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastUpdateDate] [datetime] NOT NULL,
[SourceText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Author] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Notes] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[Ordering] [int] NOT NULL CONSTRAINT [DF_ic_Resources_Ordering] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Resources] ADD CONSTRAINT [PK_ic_Resources] PRIMARY KEY CLUSTERED  ([ResourceCode]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_IsPublished] ON [dbo].[ic_Resources] ([IsPublished], [IsDeleted]) ON [PRIMARY]
GO
