CREATE TABLE [dbo].[ic_InternetAddresses]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_InternetAddresses_Id] DEFAULT (newid()),
[Address] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AddressType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_InternetAddresses] ADD CONSTRAINT [PK_ic_InternetAddresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ic_InternetAddresses_1] ON [dbo].[ic_InternetAddresses] ([Id], [AddressType]) ON [PRIMARY]
GO
