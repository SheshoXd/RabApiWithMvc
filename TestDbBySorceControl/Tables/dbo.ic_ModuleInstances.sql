CREATE TABLE [dbo].[ic_ModuleInstances]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[KeyValue] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_ModuleInstances_KeyValue] DEFAULT (newid()),
[ModuleId] [int] NOT NULL,
[Title] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Position] [varchar] (90) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Ordering] [int] NOT NULL,
[LastPublishedDate] [datetime] NULL CONSTRAINT [DF_ic_ModuleInstances_PublishDate] DEFAULT (getdate()),
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsAdmin] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ModuleInstances] ADD CONSTRAINT [PK_ic_ModuleInstances] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ModuleInstances] ADD CONSTRAINT [IX_ic_ModuleInstances] UNIQUE NONCLUSTERED  ([KeyValue]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ModuleInstances] ADD CONSTRAINT [FK_ic_ModuleInstances_ic_Modules] FOREIGN KEY ([ModuleId]) REFERENCES [dbo].[ic_Modules] ([Id])
GO
