CREATE TABLE [dbo].[ic_MenuHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_MenuHistories_HistoryId] DEFAULT (newid()),
[ItemId] [int] NOT NULL,
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ShortName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Keywords] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IntroText] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Link] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LinkPattern] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MenuType] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Target] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ImageId] [int] NULL,
[ImageRolloverId] [int] NULL,
[AccessKey] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DefaultModuleInstanceId] [int] NULL,
[ContentId] [int] NULL,
[OpenMode] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ClassName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LayoutId] [int] NULL,
[UnsupportedDevices] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[LogId] [uniqueidentifier] NOT NULL,
[DTS] [datetime] NULL,
[BannerImageId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_MenuHistories] ADD CONSTRAINT [PK_ic_MenuHistories] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_MenuHistories] ADD CONSTRAINT [FK_ic_MenuHistories_ic_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[ic_Logs] ([Id])
GO
ALTER TABLE [dbo].[ic_MenuHistories] ADD CONSTRAINT [FK_ic_MenuHistories_ic_Menus] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Menus] ([Id])
GO
