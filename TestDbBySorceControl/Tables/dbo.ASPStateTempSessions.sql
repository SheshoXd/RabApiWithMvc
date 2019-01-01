CREATE TABLE [dbo].[ASPStateTempSessions]
(
[SessionId] [nvarchar] (88) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Created] [datetime] NOT NULL CONSTRAINT [DF__ASPStateT__Creat__1C873BEC] DEFAULT (getutcdate()),
[Expires] [datetime] NOT NULL,
[LockDate] [datetime] NOT NULL,
[LockDateLocal] [datetime] NOT NULL,
[LockCookie] [int] NOT NULL,
[Timeout] [int] NOT NULL,
[Locked] [bit] NOT NULL,
[SessionItemShort] [varbinary] (7000) NULL,
[SessionItemLong] [image] NULL,
[Flags] [int] NOT NULL CONSTRAINT [DF__ASPStateT__Flags__1D7B6025] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ASPStateTempSessions] ADD CONSTRAINT [PK__ASPState__C9F49290392DEFF4] PRIMARY KEY CLUSTERED  ([SessionId]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Index_Expires] ON [dbo].[ASPStateTempSessions] ([Expires]) ON [PRIMARY]
GO
