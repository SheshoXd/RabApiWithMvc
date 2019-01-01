CREATE TABLE [dbo].[ic_ParameterHistories]
(
[HistoryId] [uniqueidentifier] NOT NULL,
[ItemId] [int] NOT NULL,
[RefId] [varchar] (36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL,
[LogId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ParameterHistories] ADD CONSTRAINT [PK_ic_ParameterHistories] PRIMARY KEY CLUSTERED  ([HistoryId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ParameterHistories] ADD CONSTRAINT [FK_ic_ParameterHistories_ic_Logs] FOREIGN KEY ([LogId]) REFERENCES [dbo].[ic_Logs] ([Id])
GO
ALTER TABLE [dbo].[ic_ParameterHistories] ADD CONSTRAINT [FK_ic_ParameterHistories_ic_Parameters] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[ic_Parameters] ([Id])
GO
