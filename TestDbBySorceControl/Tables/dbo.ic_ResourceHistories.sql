CREATE TABLE [dbo].[ic_ResourceHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL,
[ItemId] [char] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Media] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SourceText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Author] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Notes] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Ordering] [int] NOT NULL CONSTRAINT [DF_ic_ResourceHistory_Ordering] DEFAULT ((0)),
[CurrentVersion] [uniqueidentifier] NULL,
[DTS] [datetime] NOT NULL,
[LogId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ResourceHistories] ADD CONSTRAINT [PK_ic_ResourceHistory] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ResourceHistories] ADD CONSTRAINT [FK_ic_ResourceHistory_ic_Resources] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Resources] ([ResourceCode])
GO
