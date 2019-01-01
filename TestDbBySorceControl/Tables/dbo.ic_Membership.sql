CREATE TABLE [dbo].[ic_Membership]
(
[Id] [uniqueidentifier] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[Provider] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ProvidedUserId] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Membership] ADD CONSTRAINT [PK_ic_Membership] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Membership] ADD CONSTRAINT [FK_ic_Membership_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
