SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ext_v_FAQ]
AS
SELECT        c.Id, c.CategoryId, c.Title, c.IntroText, c.FullText, c.ImageId, c.DateCreated, c.LastUpdateDate, c.IsDeleted, c.CurrentVersion, c.LanguageId, c.LanguageName, c.LanguageCode, c.LogId, c.ActionId, c.UserId, 
                         c.Comments, c.FirstName, c.MiddleName, c.LastName, c.FullName, c.ItemType, c.IsPublished, dbo.GetBitParameter('IsSpam', c.Id, 'C') AS IsSpam, dbo.GetStringParameter('IPAddress', c.Id, 'C') AS IPAddress, 
                         dbo.GetStringParameter('IPAddress2', c.Id, 'C') AS IPAddress2, dbo.GetStringParameter('Email', c.Id, 'C') AS Email, dbo.GetBitParameter('IsSticky', c.Id, 'C') AS IsSticky, dbo.ic_Categories.Title AS CategoryTitle, 
                         dbo.GetIntParameter('ViewsCount', c.Id, 'C') AS ViewsCount, dbo.GetIntParameter('LikesCount', c.Id, 'C') AS LikesCount
FROM            dbo.ic_v_ContentListing AS c LEFT OUTER JOIN
                         dbo.ic_Categories ON c.CategoryId = dbo.ic_Categories.Id
WHERE        (c.ItemType = 'Q')

GO
