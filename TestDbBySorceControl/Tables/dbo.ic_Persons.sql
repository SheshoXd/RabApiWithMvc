CREATE TABLE [dbo].[ic_Persons]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Persons_Id] DEFAULT (newid()),
[UserId] [uniqueidentifier] NULL,
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FirstName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MiddleName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Suffix] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Nationality] [int] NULL,
[Gender] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateOfBirth] [datetime] NULL,
[ImageId] [int] NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Persons] ADD CONSTRAINT [PK_ic_Persons] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_Persons_1] ON [dbo].[ic_Persons] ([Nationality]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Persons] ADD CONSTRAINT [FK_ic_Persons_ic_Assets] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
