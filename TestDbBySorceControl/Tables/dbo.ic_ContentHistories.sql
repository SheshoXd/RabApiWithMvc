CREATE TABLE [dbo].[ic_ContentHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_ContentHistories_HistoryId] DEFAULT (newid()),
[ItemId] [int] NOT NULL,
[Title] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IntroText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FullText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ImageId] [int] NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[DTS] [datetime] NOT NULL,
[LogId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ContentHistories] ADD CONSTRAINT [PK_ic_ContentHistories] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ContentHistories] ADD CONSTRAINT [FK_ic_ContentHistories_ic_Contents] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Contents] ([Id])
GO
ALTER TABLE [dbo].[ic_ContentHistories] ADD CONSTRAINT [FK_ic_ContentHistories_ic_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[ic_Logs] ([Id])
GO
