CREATE TABLE [dbo].[ext_BannerZones]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Width] [int] NOT NULL,
[Height] [int] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_BannerZones] ADD CONSTRAINT [PK_ext_BannerZone] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
