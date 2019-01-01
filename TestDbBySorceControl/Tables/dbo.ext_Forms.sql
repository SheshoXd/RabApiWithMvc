CREATE TABLE [dbo].[ext_Forms]
(
[Id] [uniqueidentifier] NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateCreated] [datetime] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[TokenId] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsSpam] [bit] NULL,
[IsResolved] [bit] NULL,
[IsDeleted] [bit] NOT NULL,
[IPAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IPAddress2] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UserAgent] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LanguageId] [int] NOT NULL,
[IsArchived] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_Forms] ADD CONSTRAINT [PK_ext_Forms] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ext_Forms_1] ON [dbo].[ext_Forms] ([Type]) INCLUDE ([DateCreated], [Id], [IsArchived], [IsDeleted], [IsResolved], [LanguageId], [PersonId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_Forms] ADD CONSTRAINT [FK_ext_Forms_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
