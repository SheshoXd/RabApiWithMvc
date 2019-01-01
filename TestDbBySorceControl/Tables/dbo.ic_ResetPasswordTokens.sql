CREATE TABLE [dbo].[ic_ResetPasswordTokens]
(
[Id] [uniqueidentifier] NOT NULL ROWGUIDCOL CONSTRAINT [DF_ic_ResetPasswordTokens_Id] DEFAULT (newid()),
[ProvidedUserId] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateCreated] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ic_ResetPasswordTokens] ADD CONSTRAINT [PK_ic_ResetPasswordTokens] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
