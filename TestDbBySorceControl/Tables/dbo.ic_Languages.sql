CREATE TABLE [dbo].[ic_Languages]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[EnglishName] [varchar] (90) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [nvarchar] (90) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LanguageCode] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsRightToLeft] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Languages] ADD CONSTRAINT [PK_ic_Languages] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_Name] ON [dbo].[ic_Languages] ([Id], [EnglishName], [LanguageCode]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_LanguageCode] ON [dbo].[ic_Languages] ([LanguageCode]) ON [PRIMARY]
GO
