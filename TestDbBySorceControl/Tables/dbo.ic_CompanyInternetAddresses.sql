CREATE TABLE [dbo].[ic_CompanyInternetAddresses]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_CompanyInternetAddresses_Id] DEFAULT (newid()),
[CompanyId] [uniqueidentifier] NOT NULL,
[InternetAddressId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyInternetAddresses] ADD CONSTRAINT [PK_ic_CompanyInternetAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ic_CompanyInternetAddresses] ON [dbo].[ic_CompanyInternetAddresses] ([CompanyId], [InternetAddressId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyInternetAddresses] ADD CONSTRAINT [FK_ic_CompanyInternetAddresses_ic_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[ic_Companies] ([Id])
GO
ALTER TABLE [dbo].[ic_CompanyInternetAddresses] ADD CONSTRAINT [FK_ic_CompanyInternetAddresses_ic_InternetAddresses] FOREIGN KEY ([InternetAddressId]) REFERENCES [dbo].[ic_InternetAddresses] ([Id])
GO
