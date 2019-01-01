CREATE TABLE [dbo].[ic_ImageThumbnails]
(
[Id] [uniqueidentifier] NOT NULL,
[ImageId] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Width] [int] NOT NULL,
[Height] [int] NOT NULL,
[ActualWidth] [int] NOT NULL,
[ActualHeight] [int] NOT NULL,
[IsMaxWidth] [bit] NOT NULL,
[IsMaxHeight] [bit] NOT NULL,
[IsWatermarked] [bit] NOT NULL,
[BackgroundColorCode] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FileName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ImageThumbnails] ADD CONSTRAINT [PK_ic_ImageThumbnails] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ImageThumbnails] ADD CONSTRAINT [FK_ic_ImageThumbnails_ic_Images] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[ic_Images] ([Id])
GO
