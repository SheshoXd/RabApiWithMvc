CREATE TABLE [dbo].[ic_Menus]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ShortName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Keywords] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IntroText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Link] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LinkPattern] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ic_Menus_LinkPattern_1] DEFAULT (N'{parent-items}/{slug-en}'),
[MenuType] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Target] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_ic_Menu_Target] DEFAULT ('_self'),
[ImageId] [int] NULL,
[AccessKey] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[RelativeOrdering] [int] NOT NULL CONSTRAINT [DF_ic_Menus_RelativeOrdering_1] DEFAULT ((0)),
[ParentId] [int] NOT NULL,
[Sublevel] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL CONSTRAINT [DF_ic_Menus_PublishDate] DEFAULT (getdate()),
[DefaultModuleInstanceId] [int] NULL,
[ContentId] [int] NULL,
[ClassName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsPublished] [bit] NOT NULL CONSTRAINT [DF_ic_Menus_IsPublished] DEFAULT ((1)),
[IsInvisible] [bit] NOT NULL CONSTRAINT [DF_ic_Menus_IsInvisible] DEFAULT ((0)),
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_Menus_IsActive] DEFAULT ((1)),
[CurrentVersion] [uniqueidentifier] NULL,
[LayoutId] [int] NULL CONSTRAINT [DF_ic_Menus_LayoutId] DEFAULT ((1)),
[UnsupportedDevices] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsHomepage] [bit] NULL CONSTRAINT [ADDIsHomepageDefault] DEFAULT ((0)),
[MenuContantText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MenuContantRef] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BannerImageId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [PK_ic_Menu] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [FK_ic_Menus_ic_Assets] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [FK_ic_Menus_ic_Contents] FOREIGN KEY ([ContentId]) REFERENCES [dbo].[ic_Contents] ([Id])
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [FK_ic_Menus_ic_Layouts] FOREIGN KEY ([LayoutId]) REFERENCES [dbo].[ic_Layouts] ([Id])
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [FK_ic_Menus_ic_MenuType] FOREIGN KEY ([MenuType]) REFERENCES [dbo].[ic_MenuType] ([MenuType])
GO
ALTER TABLE [dbo].[ic_Menus] ADD CONSTRAINT [FK_ic_Menus_ic_ModuleInstances] FOREIGN KEY ([DefaultModuleInstanceId]) REFERENCES [dbo].[ic_ModuleInstances] ([Id])
GO
