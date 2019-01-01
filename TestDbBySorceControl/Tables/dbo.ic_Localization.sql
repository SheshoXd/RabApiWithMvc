CREATE TABLE [dbo].[ic_Localization]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Localization_Id] DEFAULT (newid()),
[LanguageId] [int] NOT NULL,
[GroupId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Localization_GroupId] DEFAULT (newid()),
[RefId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefType] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Localization] ADD CONSTRAINT [PK_ic_Localization] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Localization_3] ON [dbo].[ic_Localization] ([LanguageId]) INCLUDE ([GroupId], [RefId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Localization_4] ON [dbo].[ic_Localization] ([LanguageId], [GroupId]) INCLUDE ([RefId]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_Unique] ON [dbo].[ic_Localization] ([LanguageId], [RefId], [RefType], [IsDeleted]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Localization_2] ON [dbo].[ic_Localization] ([LanguageId], [RefType], [IsDeleted]) INCLUDE ([RefId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_RefId_RefType] ON [dbo].[ic_Localization] ([RefId], [RefType]) INCLUDE ([GroupId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Localization_1] ON [dbo].[ic_Localization] ([RefType], [IsDeleted]) INCLUDE ([LanguageId], [RefId]) ON [PRIMARY]
GO
