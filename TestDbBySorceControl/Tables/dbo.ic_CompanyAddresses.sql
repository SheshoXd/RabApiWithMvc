CREATE TABLE [dbo].[ic_CompanyAddresses]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_CompanyAddresses_Id] DEFAULT (newid()),
[CompanyId] [uniqueidentifier] NOT NULL,
[AddressId] [uniqueidentifier] NOT NULL,
[IsDefault] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyAddresses] ADD CONSTRAINT [PK_ic_CompanyAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ic_CompanyAddresses] ON [dbo].[ic_CompanyAddresses] ([CompanyId], [AddressId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_CompanyAddresses] ADD CONSTRAINT [FK_ic_CompanyAddresses_ic_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[ic_Addresses] ([Id])
GO
ALTER TABLE [dbo].[ic_CompanyAddresses] ADD CONSTRAINT [FK_ic_CompanyAddresses_ic_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[ic_Companies] ([Id])
GO
