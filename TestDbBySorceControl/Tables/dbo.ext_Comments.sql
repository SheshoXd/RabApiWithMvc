CREATE TABLE [dbo].[ext_Comments]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ext_Comments_Id] DEFAULT (newid()),
[RefTable] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[RefId] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FirstName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MiddleName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Message] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateApproved] [datetime] NULL,
[IsModifiedByAdmin] [bit] NULL,
[IsApproved] [bit] NULL,
[IsSpam] [bit] NULL,
[IsDeleted] [bit] NOT NULL,
[IPAddress] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IPAddress2] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UserAgent] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_Comments] ADD CONSTRAINT [PK_ext_Comments] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
