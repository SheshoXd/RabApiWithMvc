SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE VIEW [dbo].[ext_v_WinnersListing]
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
    dbo.GetStringParameter('EditionCategory', c.Id, 'C') AS EditionCategory, 
    dbo.GetStringParameter('Edition', c.Id, 'C') AS Edition, 
    dbo.GetDateParameter('PublishDate', c.Id, 'C') AS PublishDate,
    dbo.GetStringParameter('CountryFlag', c.Id, 'C') AS CountryFlag,
  dbo.GetStringParameter('EntityName', c.Id, 'C') AS EntityName,
  dbo.GetStringParameter('EntityLogo', c.Id, 'C') AS EntityLogo,
    dbo.GetStringParameter('WinnerName', c.Id, 'C') AS WinnerName,
	    dbo.GetIntParameter('Ordering', c.Id, 'C') AS Ordering
FROM dbo.ic_v_ContentListing AS c
WHERE (c.ItemType = '1')



GO
