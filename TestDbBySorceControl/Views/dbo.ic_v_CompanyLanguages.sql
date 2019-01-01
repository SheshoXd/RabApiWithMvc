SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_CompanyLanguages]
AS
SELECT DISTINCT 
                      dbo.ic_Localization.RefId AS CompanyId, dbo.ic_Localization.LanguageId, dbo.ic_Languages.EnglishName, dbo.ic_Languages.LanguageCode
FROM         dbo.ic_Localization INNER JOIN
                      dbo.ic_Languages ON dbo.ic_Localization.LanguageId = dbo.ic_Languages.Id
WHERE     (dbo.ic_Localization.RefType = 'O') AND (dbo.ic_Localization.IsDeleted = 0)
GO
