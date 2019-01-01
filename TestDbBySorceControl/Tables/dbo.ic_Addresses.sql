CREATE TABLE [dbo].[ic_Addresses]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Addresses_Id] DEFAULT (newid()),
[StreetLine1] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[StreetLine2] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StreetLine3] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[State] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Country] [int] NOT NULL,
[PostCode] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ZipCode] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[POBox] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Latitude] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Longitude] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Addresses] ADD CONSTRAINT [PK_ic_Addresses] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
