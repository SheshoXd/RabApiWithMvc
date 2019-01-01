SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE VIEW [dbo].[ic_v_user_MenuListing]
AS
SELECT     m.Id, m.Name, m.ShortName, m.Title,m.MenuContantText,m.MenuContantRef, m.Type, u.FullUrl, m.IntroText, m.Link, m.ClassName, m.MenuType, l.LanguageId, l.LanguageCode, m.ParentId, m.Sublevel, 
                      m.IsPublished, m.IsInvisible, m.IsDeleted, m.RelativeOrdering, m.ImageId,m.BannerImageId , a.ImageId AS AssetImageId, s.ImageId AS AssetBannerImageId
FROM         dbo.ic_Menus AS m LEFT OUTER JOIN
                          (SELECT     Id, FullUrl, MenuId, ModuleInstanceId, ItemId, ItemType, RoutingEntryId, IsDeleted, NewUrlId, ViewsCount
                             FROM         dbo.ic_URLLookup
                             WHERE     (ItemType IS NULL) AND (IsDeleted = 0)) AS u ON m.Id = u.MenuId INNER JOIN
                      dbo.ic_v_MenuLanguages AS l ON l.MenuId = m.Id LEFT OUTER JOIN
                      dbo.ic_Assets AS a ON m.ImageId = a.Id LEFT OUTER JOIN
						 dbo.ic_Assets AS s ON m.BannerImageId = s.Id





GO
