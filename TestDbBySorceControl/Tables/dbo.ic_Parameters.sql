CREATE TABLE [dbo].[ic_Parameters]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[RefId] [varchar] (36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[CurrentVersion] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Parameters] ADD CONSTRAINT [PK_ic_Parameters] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Parameters_1] ON [dbo].[ic_Parameters] ([Name]) INCLUDE ([RefId], [RefType], [Value]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_RefId] ON [dbo].[ic_Parameters] ([RefId], [RefType], [Name]) INCLUDE ([Id], [Value]) ON [PRIMARY]
GO
