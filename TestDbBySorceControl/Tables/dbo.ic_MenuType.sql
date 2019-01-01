CREATE TABLE [dbo].[ic_MenuType]
(
[MenuType] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Title] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL,
[IsAdmin] [bit] NOT NULL CONSTRAINT [DF_ic_MenuType_IsAdmin] DEFAULT ((0)),
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_MenuType] ADD CONSTRAINT [PK_ic_MenuType_1] PRIMARY KEY CLUSTERED  ([MenuType]) ON [PRIMARY]
GO
