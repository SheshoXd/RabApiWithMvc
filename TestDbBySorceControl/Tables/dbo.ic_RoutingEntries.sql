CREATE TABLE [dbo].[ic_RoutingEntries]
(
[Id] [int] NOT NULL IDENTITY(2, 1),
[RoleName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ModuleInstanceId] [int] NOT NULL,
[Pattern] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_RoutingEntries] ADD CONSTRAINT [PK_ic_RoutingEntries] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_RoutingEntries] ADD CONSTRAINT [FK_ic_RoutingEntries_ic_ModuleInstances] FOREIGN KEY ([ModuleInstanceId]) REFERENCES [dbo].[ic_ModuleInstances] ([Id])
GO
