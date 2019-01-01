CREATE TABLE [dbo].[ic_PersonCompanies]
(
[Id] [uniqueidentifier] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[CompanyId] [uniqueidentifier] NOT NULL,
[Designation] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonCompanies] ADD CONSTRAINT [PK_ic_PersonCompanies] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonCompanies] ADD CONSTRAINT [FK_ic_PersonCompanies_ic_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[ic_Companies] ([Id])
GO
ALTER TABLE [dbo].[ic_PersonCompanies] ADD CONSTRAINT [FK_ic_PersonCompanies_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
