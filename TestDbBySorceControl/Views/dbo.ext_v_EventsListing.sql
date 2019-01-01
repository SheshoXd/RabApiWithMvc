SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/*---------------------------------------------------*/
CREATE VIEW [dbo].[ext_v_EventsListing]
AS
SELECT        c.Id, c.Title, c.IntroText, c.FullText, c.ImageId, c.DateCreated, c.LastUpdateDate, c.IsDeleted, c.CurrentVersion, c.LanguageId, c.LanguageName, c.LanguageCode, c.LogId, c.ActionId, c.UserId, c.Comments, c.FirstName, 
                         c.MiddleName, c.LastName, c.FullName, c.CategoryId, c.ItemType, c.IsPublished, dbo.GetDateParameter('EventStartDate', c.Id, N'C') AS EventStartDate, dbo.GetDateParameter('EventEndDate', c.Id, N'C') AS EventEndDate, 
                         dbo.GetBitParameter('IsSticky', c.Id, 'C') AS IsSticky, dbo.GetBitParameter('IsRecurring', c.Id, 'C') AS IsRecurring, dbo.GetStringParameter('Slug', c.Id, 'C') AS Slug, dbo.GetStringParameter('Venue', c.Id, 'C') AS Venue, 
                         dbo.GetStringParameter('Mobile', c.Id, 'C') AS Mobile, dbo.GetStringParameter('InvetTo', c.Id, 'C') AS InvetTo, u.FullUrl, u.ViewsCount, dbo.GetIntParameter('CommentsCount', c.Id, 'C') AS CommentsCount, 
                         dbo.GetStringParameter('LocationLongitude', c.Id, 'C') AS LocationLongitude, dbo.GetStringParameter('LocationLatitude', c.Id, 'C') AS LocationLatitude
FROM            dbo.ic_v_ContentListing AS c INNER JOIN
                             (SELECT DISTINCT CAST(ItemId AS INT) AS ContentId, FullUrl, ViewsCount
                                FROM            dbo.ic_URLLookup WITH (nolock)
                                WHERE        (ItemType = 'C') AND (IsDeleted = 0)) AS u ON u.ContentId = c.Id
WHERE        (c.ItemType = 'E')

GO
