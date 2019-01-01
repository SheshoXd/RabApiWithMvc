CREATE TABLE [dbo].[ic_IndexStatus]
(
[Id] [uniqueidentifier] NOT NULL,
[ItemRefTable] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ItemRefId] [sql_variant] NOT NULL,
[LastUpdateDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_IndexStatus] ADD CONSTRAINT [PK_ic_IndexStatus] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
