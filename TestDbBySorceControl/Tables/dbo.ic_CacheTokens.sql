CREATE TABLE [dbo].[ic_CacheTokens]
(
[Id] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LastCacheTime] [datetime] NOT NULL,
[RelatedTables] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CacheTokens] ADD CONSTRAINT [PK_ic_sys_CacheTokens] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
