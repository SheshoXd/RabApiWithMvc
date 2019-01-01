SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





CREATE VIEW [dbo].[ic_v_MenuListing]
AS
SELECT        m.Id, m.Name, m.ShortName, m.Title, m.Type, m.MenuType, m.RelativeOrdering, l.LanguageId, m.DefaultModuleInstanceId, m.ContentId, m.IsPublished, m.IsDeleted, m.IsInvisible, u.ViewsCount, m.ParentId, m.Sublevel, 
                         m.DateCreated, m.LastUpdateDate, m.CurrentVersion,m.MenuContantRef,m.MenuContantText, u.FullUrl, l.EnglishName AS LanguageName, l.LanguageCode, dbo.ic_v_MenuHistories.LogId, dbo.ic_v_MenuHistories.ActionId, dbo.ic_v_MenuHistories.UserId, 
                         dbo.ic_v_MenuHistories.Comments, m.IntroText, dbo.ic_MenuType.Title AS MenuTypeTitle, dbo.ic_MenuType.IsAdmin, dbo.ic_v_MenuHistories.FullName AS UserFullName, m.Link, m.LayoutId, m.UnsupportedDevices, 
                         m.ClassName, l.GroupId
FROM            dbo.ic_Menus AS m LEFT OUTER JOIN
                             (SELECT        Id, FullUrl, MenuId, ModuleInstanceId, ItemId, ItemType, RoutingEntryId, IsDeleted, NewUrlId, ViewsCount
                               FROM            dbo.ic_URLLookup
                               WHERE        (ItemType IS NULL) AND (IsDeleted = 0)) AS u ON m.Id = u.MenuId INNER JOIN
                         dbo.ic_v_MenuLanguages AS l ON l.MenuId = m.Id INNER JOIN
                         dbo.ic_v_MenuHistories ON m.CurrentVersion = dbo.ic_v_MenuHistories.HistoryId INNER JOIN
                         dbo.ic_MenuType ON m.MenuType = dbo.ic_MenuType.MenuType





GO
