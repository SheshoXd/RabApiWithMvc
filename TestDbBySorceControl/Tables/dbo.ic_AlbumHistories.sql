CREATE TABLE [dbo].[ic_AlbumHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_AlbumHistories_HistoryId] DEFAULT (newid()),
[ItemId] [int] NOT NULL,
[Title] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CategoryId] [int] NULL,
[ImageId] [int] NULL,
[AlbumDate] [datetime] NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[DTS] [datetime] NOT NULL,
[LogId] [uniqueidentifier] NOT NULL,
[IsDefault] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_AlbumHistories] ADD CONSTRAINT [PK_ic_AlbumHistories] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_AlbumHistories] ADD CONSTRAINT [FK_ic_AlbumHistories_ic_Albums] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Albums] ([Id])
GO
ALTER TABLE [dbo].[ic_AlbumHistories] ADD CONSTRAINT [FK_ic_AlbumHistories_ic_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[ic_Logs] ([Id])
GO
