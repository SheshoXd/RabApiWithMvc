CREATE TABLE [dbo].[ic_Logs]
(
[Id] [uniqueidentifier] NOT NULL,
[RefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefId] [varchar] (36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefHistoryId] [uniqueidentifier] NULL,
[ActionId] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ActivityDate] [datetime] NOT NULL,
[UserId] [uniqueidentifier] NULL,
[Comments] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Logs] ADD CONSTRAINT [PK_ic_Logs] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
