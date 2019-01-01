CREATE TABLE [dbo].[ic_Companies]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ic_Companies_Id] DEFAULT (newid()),
[TradeName] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CountryId] [int] NULL,
[LogoId] [int] NULL,
[Type] [int] NULL,
[Email] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Website] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_ic_Companies_DateCreate] DEFAULT (getutcdate()),
[IsDeleted] [bit] NOT NULL,
[WorkingDays] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WorkingHours] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Companies] ADD CONSTRAINT [PK_ic_Companies] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Companies] ADD CONSTRAINT [FK_ic_Companies_ic_Assets] FOREIGN KEY ([LogoId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
