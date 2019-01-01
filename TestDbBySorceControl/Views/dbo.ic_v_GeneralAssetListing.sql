SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_GeneralAssetListing]
AS
SELECT     dbo.ic_Assets.Id, dbo.ic_Assets.Title, dbo.ic_Assets.Description, dbo.ic_Assets.Type, dbo.ic_Assets.MimeType, dbo.ic_Assets.ImageId, dbo.ic_Assets.DateCreated, 
                      dbo.ic_Assets.Size, dbo.ic_Assets.OriginalFileName, dbo.ic_Assets.GeneratedFileName, dbo.ic_Assets.IsDeleted, dbo.ic_v_AssetLanguages.LanguageId, 
                      dbo.ic_v_AssetLanguages.EnglishName AS LanguageName, dbo.ic_v_AssetLanguages.LanguageCode, dbo.ic_Assets.LastUpdateDate, dbo.ic_Assets.IsPublished, 
                      dbo.ic_Assets.DownloadCounter, dbo.ic_Assets.IsSticky, dbo.ic_Assets.ItemDate,
STUFF
                                                  ((SELECT     ',' + dbo.ic_Categories.Title
                                                      FROM          dbo.ic_AssetCategories INNER JOIN
                                                                             dbo.ic_Categories ON dbo.ic_Categories.Id = dbo.GetLocalizedItem(CAST(dbo.ic_AssetCategories.CategoryId AS VARCHAR), 'c', 
                                                                             dbo.ic_v_AssetLanguages.LanguageId)
                                                      WHERE      dbo.ic_AssetCategories.AssetId = dbo.ic_Assets.Id FOR XML PATH('')), 1, 1, '') AS CategoryTitle
FROM         dbo.ic_v_AssetLanguages INNER JOIN
                      dbo.ic_Assets ON dbo.ic_v_AssetLanguages.AssetId = dbo.ic_Assets.Id
GO
