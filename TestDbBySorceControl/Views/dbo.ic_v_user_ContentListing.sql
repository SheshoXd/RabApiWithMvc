SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_user_ContentListing]
AS
SELECT     dbo.ic_Contents.Id, dbo.ic_Contents.Title, dbo.ic_Contents.IntroText, dbo.ic_Contents.FullText, dbo.ic_Contents.ImageId, dbo.ic_Contents.DateCreated, 
                      dbo.ic_Contents.LastUpdateDate, dbo.ic_Contents.IsDeleted, dbo.ic_Contents.CurrentVersion, dbo.ic_v_ContentLanguages.LanguageId, 
                      dbo.ic_v_ContentLanguages.EnglishName AS LanguageName, dbo.ic_v_ContentLanguages.LanguageCode, dbo.ic_Contents.CategoryId, dbo.ic_Contents.ItemType, 
                      dbo.ic_Contents.IsPublished
FROM         dbo.ic_Contents INNER JOIN
                      dbo.ic_v_ContentLanguages ON dbo.ic_Contents.Id = dbo.ic_v_ContentLanguages.ContentId
GO
