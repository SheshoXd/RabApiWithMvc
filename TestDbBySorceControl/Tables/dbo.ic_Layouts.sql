CREATE TABLE [dbo].[ic_Layouts]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsAdmin] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL CONSTRAINT [DF_ic_Layouts_IsDefault] DEFAULT ((0)),
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Layouts] ADD CONSTRAINT [PK_ic_Layouts] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
