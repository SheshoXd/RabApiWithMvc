CREATE TABLE [dbo].[ext_NewsletterIssues]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[NewsletterTemplateId] [int] NOT NULL,
[Title] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IssueNo] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[IssueDate] [datetime] NOT NULL,
[Path] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateCreated] [datetime] NOT NULL,
[IsPublished] [bit] NOT NULL,
[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_NewsletterIssues] ADD CONSTRAINT [PK_ic_NewsletterIssues] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ext_NewsletterIssues] ADD CONSTRAINT [FK_ext_NewsletterIssues_ic_Contents] FOREIGN KEY ([NewsletterTemplateId]) REFERENCES [dbo].[ic_Contents] ([Id])
GO
