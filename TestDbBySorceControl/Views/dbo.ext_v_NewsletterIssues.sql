SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_NewsletterIssues]
AS
SELECT     dbo.ext_NewsletterIssues.Id, dbo.ext_NewsletterIssues.NewsletterTemplateId, dbo.ext_NewsletterIssues.Title, dbo.ext_NewsletterIssues.Description, 
                      dbo.ext_NewsletterIssues.IssueNo, dbo.ext_NewsletterIssues.IssueDate, dbo.ext_NewsletterIssues.Path, dbo.ext_NewsletterIssues.DateCreated, 
                      dbo.ext_NewsletterIssues.IsPublished, dbo.ext_NewsletterIssues.IsDeleted, dbo.ic_Contents.Title AS TemplateTitle, dbo.ic_Contents.FullText AS Template
FROM         dbo.ext_NewsletterIssues INNER JOIN
                      dbo.ic_Contents ON dbo.ext_NewsletterIssues.NewsletterTemplateId = dbo.ic_Contents.Id
GO
