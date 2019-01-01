CREATE TABLE [dbo].[ic_Assets]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[CategoryId] [int] NULL,
[Title] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MimeType] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ImageId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL CONSTRAINT [DF_ic_Assets_LastUpdateDate] DEFAULT (getdate()),
[Size] [bigint] NOT NULL,
[OriginalFileName] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GeneratedFileName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsSticky] [bit] NOT NULL CONSTRAINT [DF_ic_Assets_IsSticky] DEFAULT ((0)),
[IsPublished] [bit] NOT NULL CONSTRAINT [DF_ic_Assets_IsPublished] DEFAULT ((1)),
[IsDeleted] [bit] NOT NULL,
[DownloadCounter] [int] NOT NULL CONSTRAINT [DF_ic_Assets_DownloadCounter] DEFAULT ((0)),
[ItemDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Assets] ADD CONSTRAINT [PK_ic_Documents] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Type] ON [dbo].[ic_Assets] ([Type]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Assets_1] ON [dbo].[ic_Assets] ([Type]) INCLUDE ([Id], [IsDeleted], [IsPublished]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Assets] ADD CONSTRAINT [FK_ic_Documents_ic_Images] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Images] ([Id])
GO
