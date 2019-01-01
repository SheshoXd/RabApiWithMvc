CREATE TABLE [dbo].[ic_Modules]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ControlPath] [varchar] (120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsComponent] [bit] NOT NULL,
[IsPageDependent] [bit] NOT NULL CONSTRAINT [DF_ic_Modules_IsPageDependent] DEFAULT ((0)),
[RefTypeCanHandle] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsAdmin] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Modules] ADD CONSTRAINT [PK_ic_Modules] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
