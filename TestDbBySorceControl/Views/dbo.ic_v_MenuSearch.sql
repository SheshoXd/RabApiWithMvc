SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_MenuSearch]
AS
SELECT     dbo.ic_Menus.Id, dbo.ic_Menus.Name, dbo.ic_Menus.ShortName, dbo.ic_Menus.Title, dbo.ic_Menus.Description, dbo.ic_Menus.Keywords, dbo.ic_Menus.IntroText, 
                      dbo.ic_Menus.Link, dbo.ic_Menus.ImageId, dbo.ic_v_MenuLanguages.LanguageId, dbo.ic_Menus.LastUpdateDate, dbo.ic_Menus.IsPublished, 
                      dbo.ic_Menus.IsDeleted, dbo.ic_Contents.FullText
FROM         dbo.ic_Contents INNER JOIN
                      dbo.ic_Menus ON dbo.ic_Contents.Id = dbo.ic_Menus.ContentId INNER JOIN
                      dbo.ic_v_MenuLanguages ON dbo.ic_Menus.Id = dbo.ic_v_MenuLanguages.MenuId
GO
