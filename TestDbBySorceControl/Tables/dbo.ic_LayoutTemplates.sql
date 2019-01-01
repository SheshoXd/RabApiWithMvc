CREATE TABLE [dbo].[ic_LayoutTemplates]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[LayoutId] [int] NOT NULL,
[TemplateId] [int] NOT NULL,
[DeviceType] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDefault] [bit] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[CacheFilePath] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_LayoutTemplates] ADD CONSTRAINT [PK_ic_LayoutTemplates] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_LayoutTemplates] ADD CONSTRAINT [FK_ic_LayoutTemplates_ic_Devices] FOREIGN KEY ([DeviceType]) REFERENCES [dbo].[ic_Devices] ([DeviceCode])
GO
ALTER TABLE [dbo].[ic_LayoutTemplates] ADD CONSTRAINT [FK_ic_LayoutTemplates_ic_Layouts] FOREIGN KEY ([LayoutId]) REFERENCES [dbo].[ic_Layouts] ([Id])
GO
ALTER TABLE [dbo].[ic_LayoutTemplates] ADD CONSTRAINT [FK_ic_LayoutTemplates_ic_Templates] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[ic_Templates] ([Id])
GO
