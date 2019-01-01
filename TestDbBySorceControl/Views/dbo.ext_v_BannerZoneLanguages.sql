SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_BannerZoneLanguages]
AS
SELECT DISTINCT 
                      CASE dbo.ic_Localization.RefType WHEN 'Z' THEN CAST(dbo.ic_Localization.RefId AS int) ELSE NULL END AS BannerZoneId, dbo.ic_Localization.LanguageId, 
                      dbo.ic_Languages.EnglishName, dbo.ic_Languages.LanguageCode
FROM         dbo.ic_Localization INNER JOIN
                      dbo.ic_Languages ON dbo.ic_Localization.LanguageId = dbo.ic_Languages.Id
WHERE     (dbo.ic_Localization.RefType = 'Z') AND (dbo.ic_Localization.IsDeleted = 0)
GO
