CREATE TABLE [dbo].[ic_PersonInternetAddresses]
(
[Id] [uniqueidentifier] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[InternetAddressId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonInternetAddresses] ADD CONSTRAINT [PK_ic_PersonInternetAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_PersonInternetAddresses_1] ON [dbo].[ic_PersonInternetAddresses] ([PersonId], [InternetAddressId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonInternetAddresses] ADD CONSTRAINT [FK_ic_PersonInternetAddresses_ic_InternetAddresses] FOREIGN KEY ([InternetAddressId]) REFERENCES [dbo].[ic_InternetAddresses] ([Id])
GO
ALTER TABLE [dbo].[ic_PersonInternetAddresses] ADD CONSTRAINT [FK_ic_PersonInternetAddresses_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
