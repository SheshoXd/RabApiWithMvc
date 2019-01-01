CREATE TABLE [dbo].[ic_CompanyContactNumbers]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_CompanyContactNumbers_Id] DEFAULT (newid()),
[CompanyId] [uniqueidentifier] NOT NULL,
[ContactNumberId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyContactNumbers] ADD CONSTRAINT [PK_ic_CompanyContactNumbers] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ic_CompanyContactNumbers] ON [dbo].[ic_CompanyContactNumbers] ([CompanyId], [ContactNumberId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyContactNumbers] ADD CONSTRAINT [FK_ic_CompanyContactNumbers_ic_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[ic_Companies] ([Id])
GO
ALTER TABLE [dbo].[ic_CompanyContactNumbers] ADD CONSTRAINT [FK_ic_CompanyContactNumbers_ic_ContactNumbers] FOREIGN KEY ([ContactNumberId]) REFERENCES [dbo].[ic_ContactNumbers] ([Id])
GO
