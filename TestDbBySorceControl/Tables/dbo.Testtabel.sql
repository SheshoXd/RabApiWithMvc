CREATE TABLE [dbo].[Testtabel]
(
[id] [int] NOT NULL,
[name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[password] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Testtabel] ADD CONSTRAINT [PK_Testtabel] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
