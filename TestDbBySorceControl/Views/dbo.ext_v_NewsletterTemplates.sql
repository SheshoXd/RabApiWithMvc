SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_NewsletterTemplates]
AS
SELECT     dbo.ic_Contents.Id, dbo.ic_Contents.Title, dbo.ic_Contents.IntroText, dbo.ic_Contents.FullText, dbo.ic_Contents.DateCreated, dbo.ic_Contents.LastUpdateDate, 
                      dbo.ic_Contents.IsDeleted, dbo.ic_Contents.CurrentVersion, dbo.ic_v_ContentLanguages.LanguageId, dbo.ic_v_ContentLanguages.EnglishName AS LanguageName, 
                      dbo.ic_v_ContentLanguages.LanguageCode, dbo.ic_v_ContentHistories.LogId, dbo.ic_v_ContentHistories.ActionId, dbo.ic_v_ContentHistories.UserId, 
                      dbo.ic_v_ContentHistories.Comments, dbo.ic_v_ContentHistories.FirstName, dbo.ic_v_ContentHistories.MiddleName, dbo.ic_v_ContentHistories.LastName, 
                      dbo.ic_v_ContentHistories.FullName, dbo.ic_Contents.ItemType, dbo.ic_Contents.IsPublished, dbo.GetStringParameter('AssemblyInfo', dbo.ic_Contents.Id, 'C') 
                      AS AssemblyInfo
FROM         dbo.ic_Contents INNER JOIN
                      dbo.ic_v_ContentLanguages ON dbo.ic_Contents.Id = dbo.ic_v_ContentLanguages.ContentId INNER JOIN
                      dbo.ic_v_ContentHistories ON dbo.ic_Contents.CurrentVersion = dbo.ic_v_ContentHistories.HistoryId
WHERE     (dbo.ic_Contents.ItemType = 'T')
GO
