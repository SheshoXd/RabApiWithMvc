CREATE TABLE [dbo].[ic_Images]
(
[Id] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Width] [int] NOT NULL,
[Height] [int] NOT NULL,
[HorizontalResolution] [int] NOT NULL,
[VerticalResolution] [int] NOT NULL,
[BitDepth] [int] NOT NULL,
[FileName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_Images] ADD CONSTRAINT [PK_ic_Images] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
