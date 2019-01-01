SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_BannerZoneListing]
AS
SELECT     dbo.ext_BannerZones.Id, dbo.ext_BannerZones.Title, dbo.ext_BannerZones.Description, dbo.ext_BannerZones.Width, dbo.ext_BannerZones.Height, 
                      dbo.ext_BannerZones.IsPublished, dbo.ext_BannerZones.IsDeleted, dbo.ext_v_BannerZoneLanguages.LanguageId, 
                      dbo.ext_v_BannerZoneLanguages.LanguageCode, dbo.ext_v_BannerZoneLanguages.EnglishName AS LanguageName,
                          (SELECT     COUNT(*) AS Expr1
                            FROM          dbo.ext_v_BannerZoneAssets_md
                            WHERE      (ZoneId = dbo.ext_BannerZones.Id)) AS ItemCount
FROM         dbo.ext_BannerZones INNER JOIN
                      dbo.ext_v_BannerZoneLanguages ON dbo.ext_BannerZones.Id = dbo.ext_v_BannerZoneLanguages.BannerZoneId
GO
