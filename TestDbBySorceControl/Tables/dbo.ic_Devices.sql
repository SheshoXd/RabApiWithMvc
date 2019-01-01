CREATE TABLE [dbo].[ic_Devices]
(
[DeviceCode] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Title] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDefault] [bit] NOT NULL,
[Type] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Slug] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsJavascriptEnabled] [bit] NOT NULL,
[IsFlashEnabled] [bit] NOT NULL,
[ScreenWidth] [int] NULL,
[ScreenHeight] [int] NULL,
[Notes] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_ic_Devices_IsDeleted] DEFAULT ((0)),
[UserAgentRegEx] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DetectorAssemblyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DetectorClassName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Priority] [int] NOT NULL CONSTRAINT [DF_ic_Devices_Priority] DEFAULT ((10))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Devices] ADD CONSTRAINT [PK_ic_Devices] PRIMARY KEY CLUSTERED  ([DeviceCode]) ON [PRIMARY]
GO
