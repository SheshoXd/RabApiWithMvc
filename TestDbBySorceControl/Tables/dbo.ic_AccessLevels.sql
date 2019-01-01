CREATE TABLE [dbo].[ic_AccessLevels]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_AccessLevels_Id] DEFAULT (newid()),
[RefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RoleName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AccessType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_AccessLevels_IsActive] DEFAULT ((1))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_AccessLevels] ADD CONSTRAINT [PK_ic_AccessLevels] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
