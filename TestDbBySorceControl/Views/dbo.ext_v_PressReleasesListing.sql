SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_PressReleasesListing]
AS
SELECT 
	c.Id, 
	c.Title, 
	c.IntroText, 
	c.FullText, 
	c.ImageId, 
	c.DateCreated, 
	c.LastUpdateDate, 
	c.IsDeleted, 
	c.CurrentVersion, 
	c.LanguageId, 
	c.LanguageName, 
    c.LanguageCode, 
    c.LogId, 
    c.ActionId, 
    c.UserId, 
    c.Comments, 
    c.FirstName, 
    c.MiddleName, 
    c.LastName, 
    c.FullName, 
    c.CategoryId, 
    c.ItemType, 
    c.IsPublished, 
    dbo.GetStringParameter('SubTitle', c.Id, 'C') AS SubTitle, 
    dbo.GetStringParameter('Synopsis', c.Id, 'C') AS Synopsis, 
    dbo.GetDateParameter('NewsDate', c.Id, 'C') AS NewsDate, 
    dbo.GetCharParameter('NewsType', c.Id, 'C') AS NewsType, 
    dbo.GetDateParameter('PublishDate', c.Id, 'C') AS PublishDate, 
    dbo.GetDateParameter('ArchiveDate', c.Id, 'C') AS ArchiveDate, 
    dbo.GetBitParameter('IsSticky', c.Id, 'C') AS IsSticky, 
    dbo.GetBitParameter('IsArchived', c.Id, 'C') AS IsArchived, 
    dbo.GetStringParameter('Slug', c.Id, 'C') AS Slug, 
    u.FullUrl, 
    u.ViewsCount
FROM dbo.ic_v_ContentListing AS c INNER JOIN
(
	SELECT 
		DISTINCT CAST(ItemId AS INT) AS ContentId, 
		FullUrl, 
		ViewsCount
    FROM dbo.ic_URLLookup
    WHERE (ItemType = 'C') AND (IsDeleted = 0)
) AS u ON u.ContentId = c.Id
WHERE (c.ItemType = 'N')
GO
