CREATE TABLE [dbo].[ic_Albums]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CategoryId] [int] NULL,
[ImageId] [int] NULL,
[AlbumDate] [datetime] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL,
[IsSticky] [bit] NOT NULL,
[Slug] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ItemCount] [int] NOT NULL CONSTRAINT [DF_ic_Albums_ItemCount] DEFAULT ((0)),
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[IsDefault] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Albums] ADD CONSTRAINT [PK_ic_Albums] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Albums] ADD CONSTRAINT [FK_ic_Albums_ic_Assets] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
ALTER TABLE [dbo].[ic_Albums] ADD CONSTRAINT [FK_ic_Albums_ic_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ic_Categories] ([Id])
GO
