SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_AlbumAssetList]
AS
SELECT        dbo.ic_Assets.Title AS OriginalTitle, dbo.ic_Assets.Type, dbo.ic_Assets.MimeType, dbo.ic_Assets.ImageId, dbo.ic_Assets.DateCreated, dbo.ic_Assets.LastUpdateDate, dbo.ic_Assets.Size, dbo.ic_Assets.OriginalFileName, 
                         dbo.ic_Assets.GeneratedFileName, dbo.ic_Assets.IsSticky, dbo.ic_Assets.IsPublished, dbo.ic_Assets.IsDeleted, dbo.ic_Assets.DownloadCounter, dbo.ic_Assets.ItemDate, dbo.ic_Assets.Id, 
                         dbo.ic_v_AlbumLanguages.LanguageId, dbo.ic_v_AlbumLanguages.EnglishName AS LanguageName, dbo.ic_v_AlbumLanguages.LanguageCode, ic_f_AlbumAssets_md_1.AlbumId, dbo.ic_Assets.Title, 
                         ic_f_AlbumAssets_md_1.Ordering, dbo.ic_Assets.Description, dbo.GetStringParameter('EMBED-CODE', dbo.ic_Assets.Id, 'A') AS EmbedCode, dbo.ic_Albums.CategoryId, dbo.ic_Albums.Slug
FROM            dbo.ic_Assets INNER JOIN
                         dbo.ic_f_AlbumAssets_md() AS ic_f_AlbumAssets_md_1 ON dbo.ic_Assets.Id = ic_f_AlbumAssets_md_1.AssetId INNER JOIN
                         dbo.ic_v_AlbumLanguages ON ic_f_AlbumAssets_md_1.AlbumId = dbo.ic_v_AlbumLanguages.AlbumId LEFT OUTER JOIN
                         dbo.ic_Albums ON dbo.ic_v_AlbumLanguages.AlbumId = dbo.ic_Albums.Id

GO
