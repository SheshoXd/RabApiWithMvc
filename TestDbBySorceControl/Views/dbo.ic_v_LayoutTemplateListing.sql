SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_LayoutTemplateListing]
AS
SELECT     dbo.ic_LayoutTemplates.Id, dbo.ic_LayoutTemplates.LayoutId, dbo.ic_LayoutTemplates.TemplateId, dbo.ic_v_LayoutLanguages.LanguageId, 
                      dbo.ic_LayoutTemplates.DeviceType, dbo.ic_LayoutTemplates.IsDefault, dbo.ic_Layouts.IsAdmin, dbo.ic_LayoutTemplates.IsPublished, 
                      dbo.ic_LayoutTemplates.IsDeleted, dbo.ic_LayoutTemplates.CacheFilePath, dbo.ic_Layouts.Title, dbo.ic_v_LayoutLanguages.EnglishName AS LanguageName, 
                      dbo.ic_v_LayoutLanguages.LanguageCode, dbo.ic_Templates.Name AS TemplateName, dbo.ic_Devices.Title AS DeviceName, 
                      dbo.ic_Devices.IsDefault AS IsDefaultDevice
FROM         dbo.ic_LayoutTemplates INNER JOIN
                      dbo.ic_Layouts ON dbo.ic_LayoutTemplates.LayoutId = dbo.ic_Layouts.Id INNER JOIN
                      dbo.ic_Templates ON dbo.ic_LayoutTemplates.TemplateId = dbo.ic_Templates.Id INNER JOIN
                      dbo.ic_Devices ON dbo.ic_LayoutTemplates.DeviceType = dbo.ic_Devices.DeviceCode INNER JOIN
                      dbo.ic_v_LayoutLanguages ON dbo.ic_Layouts.Id = dbo.ic_v_LayoutLanguages.LayoutId
GO
