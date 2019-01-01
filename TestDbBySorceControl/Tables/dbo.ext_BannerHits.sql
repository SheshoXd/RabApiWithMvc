CREATE TABLE [dbo].[ext_BannerHits]
(
[Id] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_ext_BannerHits_Id] DEFAULT (newid()),
[ActionType] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[BannerId] [int] NOT NULL,
[ZoneId] [int] NOT NULL,
[DateCreated] [datetime] NOT NULL,
[IPAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IPAddress2] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UserAgent] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsSpam] [bit] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_BannerHits] ADD CONSTRAINT [PK_ext_BannerHits] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_BannerHits] ADD CONSTRAINT [FK_ext_BannerHits_ext_BannerZones] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[ext_BannerZones] ([Id])
GO
ALTER TABLE [dbo].[ext_BannerHits] ADD CONSTRAINT [FK_ext_BannerHits_ic_Assets] FOREIGN KEY ([BannerId]) REFERENCES [dbo].[ic_Assets] ([Id])
GO
