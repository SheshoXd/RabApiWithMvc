CREATE TABLE [dbo].[ic_PersonAddresses]
(
[Id] [uniqueidentifier] NOT NULL,
[PersonId] [uniqueidentifier] NOT NULL,
[AddressId] [uniqueidentifier] NOT NULL,
[IsDeleted] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonAddresses] ADD CONSTRAINT [PK_ic_PersonAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_PersonAddresses] ADD CONSTRAINT [FK_ic_PersonAddresses_ic_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[ic_Addresses] ([Id])
GO
ALTER TABLE [dbo].[ic_PersonAddresses] ADD CONSTRAINT [FK_ic_PersonAddresses_ic_Persons] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[ic_Persons] ([Id])
GO
