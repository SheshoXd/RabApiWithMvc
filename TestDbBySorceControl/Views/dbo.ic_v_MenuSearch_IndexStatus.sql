SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_MenuSearch_IndexStatus]
AS
SELECT        dbo.ic_Menus.Id, dbo.ic_Menus.Name, dbo.ic_Menus.ShortName, dbo.ic_Menus.Title, dbo.ic_Menus.Description, dbo.ic_Menus.Keywords, dbo.ic_Menus.IntroText, dbo.ic_Menus.Link, dbo.ic_Menus.ImageId, 
                         dbo.ic_v_MenuLanguages.LanguageId, dbo.ic_Menus.IsPublished, dbo.ic_Menus.IsDeleted, dbo.ic_Contents.FullText, dbo.ic_Menus.LastUpdateDate, idxStatus.LastUpdateDate AS LastStatusUpdateDate, 
                         idxStatus.ItemRefId, idxStatus.ItemRefTable
FROM            dbo.ic_Contents INNER JOIN
                         dbo.ic_Menus ON dbo.ic_Contents.Id = dbo.ic_Menus.ContentId INNER JOIN
                         dbo.ic_v_MenuLanguages ON dbo.ic_Menus.Id = dbo.ic_v_MenuLanguages.MenuId LEFT OUTER JOIN
                         dbo.ic_IndexStatus AS idxStatus ON dbo.ic_Menus.Id = CAST(idxStatus.ItemRefId AS INT) AND idxStatus.ItemRefTable = 'Menus'
WHERE        (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Menus') AND (idxStatus.LastUpdateDate IS NULL) AND (dbo.ic_Menus.MenuType <> 'adminmenu') AND (dbo.ic_Menus.IsInvisible = 0) AND (dbo.ic_Menus.MenuType <> 'hidden') OR
                         (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Menus') AND (dbo.ic_Menus.MenuType <> 'adminmenu') AND (dbo.ic_Menus.IsInvisible = 0) AND (dbo.ic_Menus.MenuType <> 'hidden') AND 
                         (dbo.ic_Menus.LastUpdateDate > idxStatus.LastUpdateDate)
GO
