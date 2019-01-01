SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_BannerZoneAssets]
AS
SELECT        dbo.ic_Assets.Description, dbo.ic_Assets.Type, dbo.ic_Assets.MimeType, dbo.ic_Assets.ImageId, dbo.ic_Assets.DateCreated, dbo.ic_Assets.LastUpdateDate, dbo.ic_Assets.Size, dbo.ic_Assets.OriginalFileName, 
                         dbo.ic_Assets.GeneratedFileName, dbo.ic_Assets.IsSticky, dbo.ic_Assets.IsPublished, dbo.ic_Assets.ItemDate, dbo.GetStringParameter('NavigateUrl', dbo.ic_Assets.Id, 'A') AS NavigateUrl, dbo.GetCharParameter('LinkTarget', 
                         dbo.ic_Assets.Id, 'A') AS Target, dbo.GetStringParameter('ConfirmationDialog', dbo.ic_Assets.Id, 'A') AS ConfirmationDialog, dbo.GetDateParameter('StartDate', dbo.ic_Assets.Id, N'A') AS StartDate, 
                         dbo.GetDateParameter('EndDate', dbo.ic_Assets.Id, N'A') AS EndDate, dbo.ic_Assets.Id AS TotalHits, dbo.ic_Assets.Id AS TotalClicks, dbo.ic_Assets.Id, dbo.ic_Assets.Title AS OriginalTitle, 
                         dbo.ext_v_BannerZoneLanguages.LanguageId, dbo.ext_v_BannerZoneLanguages.LanguageCode, dbo.ext_v_BannerZoneAssets_md.ZoneId, dbo.ext_v_BannerZoneAssets_md.Title, 
                         dbo.ext_v_BannerZoneAssets_md.Ordering
FROM            dbo.ext_v_BannerZoneLanguages INNER JOIN
                         dbo.ext_v_BannerZoneAssets_md ON dbo.ext_v_BannerZoneLanguages.BannerZoneId = dbo.ext_v_BannerZoneAssets_md.ZoneId INNER JOIN
                         dbo.ic_Assets ON dbo.ext_v_BannerZoneAssets_md.AssetId = dbo.ic_Assets.Id

GO
