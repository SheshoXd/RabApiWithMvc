CREATE TABLE [dbo].[ic_Constants]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Group] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Value] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Ordering] [int] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[Notes] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Constants] ADD CONSTRAINT [PK_ic_Constants] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Constants_1] ON [dbo].[ic_Constants] ([Group], [Name], [Value]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Constants_2] ON [dbo].[ic_Constants] ([Id], [Group], [Name], [Value], [Ordering], [IsPublished], [IsDeleted]) ON [PRIMARY]
GO
