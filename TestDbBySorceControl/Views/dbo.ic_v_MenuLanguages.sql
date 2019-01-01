SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_MenuLanguages]
AS
SELECT DISTINCT CAST(dbo.ic_Localization.RefId AS int) AS MenuId,dbo.ic_Localization.RefId, dbo.ic_Localization.LanguageId, dbo.ic_Localization.GroupId, dbo.ic_Languages.EnglishName, dbo.ic_Languages.LanguageCode
FROM         dbo.ic_Localization INNER JOIN
                     dbo.ic_Languages ON dbo.ic_Localization.LanguageId = dbo.ic_Languages.Id
WHERE     (dbo.ic_Localization.RefType = 'P') AND (dbo.ic_Localization.IsDeleted = 0)


GO
