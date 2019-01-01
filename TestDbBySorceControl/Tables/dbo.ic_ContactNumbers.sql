CREATE TABLE [dbo].[ic_ContactNumbers]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_ContactNumbers_Id] DEFAULT (newid()),
[CountryCode] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CityCode] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Number] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Extension] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MediaType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ContactNumbers] ADD CONSTRAINT [PK_ic_ContactNumbers] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
