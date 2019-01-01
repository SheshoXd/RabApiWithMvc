SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ext_v_ContentComments]
AS
SELECT     
	dbo.ext_Comments.Id, 
	dbo.ext_Comments.FirstName, 
	dbo.ext_Comments.MiddleName, 
	dbo.ext_Comments.LastName, 
	dbo.ext_Comments.Email, 
	dbo.ext_Comments.Message, 
	dbo.ext_Comments.DateAdded, 
	dbo.ext_Comments.DateApproved, 
	dbo.ext_Comments.IsApproved, 
	dbo.ext_Comments.IsDeleted, 
	dbo.ext_Comments.RefId, 
	b.Title, 
	b.LanguageId, 
	b.LanguageName
FROM dbo.ext_Comments INNER JOIN
(
	SELECT  
		dbo.ic_Contents.Id, 
		dbo.ic_Contents.Title, 
		CASE WHEN dbo.ic_v_ContentLanguages.LanguageId IS NULL THEN
			(
				SELECT LanguageId
				FROM ic_v_MenuListing WHERE ContentId = dbo.ic_Contents.Id
			)
			ELSE dbo.ic_v_ContentLanguages.LanguageId END AS LanguageId, 
		CASE WHEN dbo.ic_v_ContentLanguages.EnglishName IS NULL THEN
			(
				SELECT LanguageName
				FROM ic_v_MenuListing WHERE ContentId = dbo.ic_Contents.Id
			)
			ELSE dbo.ic_v_ContentLanguages.EnglishName END AS LanguageName
	FROM dbo.ic_Contents LEFT OUTER JOIN
	dbo.ic_v_ContentLanguages ON dbo.ic_Contents.Id = dbo.ic_v_ContentLanguages.ContentId
)b ON dbo.ext_Comments.RefId = b.Id
WHERE     (dbo.ext_Comments.RefTable = 'C')
GO
