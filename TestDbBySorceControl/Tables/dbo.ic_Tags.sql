CREATE TABLE [dbo].[ic_Tags]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Tags_Id] DEFAULT (newid()),
[TagWord] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_Tags_IsDeleted] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Tags] ADD CONSTRAINT [PK_ic_Tags] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
