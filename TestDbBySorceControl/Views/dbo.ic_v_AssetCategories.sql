SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_AssetCategories]
AS
SELECT     dbo.ic_Assets.Id, dbo.ic_v_AssetLanguages.LanguageId, dbo.ic_v_AssetLanguages.EnglishName, dbo.ic_AssetCategories.CategoryId,
                          (SELECT     Title
                             FROM         dbo.ic_Categories
                             WHERE     (Id = dbo.GetLocalizedItem(CAST(dbo.ic_AssetCategories.CategoryId AS VARCHAR), 'c', dbo.ic_v_AssetLanguages.LanguageId))) AS CategoryTitle, 
                      dbo.ic_Assets.IsDeleted, dbo.ic_Assets.IsPublished
FROM         dbo.ic_v_AssetLanguages INNER JOIN
                      dbo.ic_Assets ON dbo.ic_v_AssetLanguages.AssetId = dbo.ic_Assets.Id LEFT OUTER JOIN
                      dbo.ic_AssetCategories ON dbo.ic_Assets.Id = dbo.ic_AssetCategories.AssetId
GO
