CREATE TABLE [dbo].[ic_CategoryHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL,
[ItemId] [int] NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ParentId] [int] NULL,
[SubLevel] [int] NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NULL,
[Slug] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[DTS] [datetime] NOT NULL,
[LogId] [uniqueidentifier] NOT NULL,
[ImageId] [int] NULL,
[CssClass] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Ordering] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CategoryHistories] ADD CONSTRAINT [PK_ic_CategoryHistories] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CategoryHistories] ADD CONSTRAINT [FK_ic_CategoryHistories_ic_Categories] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Categories] ([Id])
GO
ALTER TABLE [dbo].[ic_CategoryHistories] ADD CONSTRAINT [FK_ic_CategoryHistories_ic_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[ic_Logs] ([Id])
GO
