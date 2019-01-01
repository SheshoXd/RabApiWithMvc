CREATE TABLE [dbo].[ASPStateTempApplications]
(
[AppId] [int] NOT NULL,
[AppName] [char] (280) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ASPStateTempApplications] ADD CONSTRAINT [PK__ASPState__8E2CF7F905C30B4F] PRIMARY KEY CLUSTERED  ([AppId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Index_AppName] ON [dbo].[ASPStateTempApplications] ([AppName]) ON [PRIMARY]
GO
