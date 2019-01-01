SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_ModuleInstances]
AS
SELECT     dbo.ic_ModuleInstances.Id, dbo.ic_ModuleInstances.KeyValue, dbo.ic_ModuleInstances.ModuleId, dbo.ic_Modules.Title AS ModuleTitle, 
                      dbo.ic_ModuleInstances.Title, dbo.ic_ModuleInstances.Description, dbo.ic_ModuleInstances.Position, dbo.ic_ModuleInstances.Ordering, 
                      dbo.ic_ModuleInstances.LastPublishedDate, dbo.ic_ModuleInstances.IsPublished, dbo.ic_ModuleInstances.IsDeleted, dbo.ic_Modules.IsAdmin, 
                      dbo.ic_Modules.IsPageDependent, dbo.ic_Modules.IsComponent, dbo.ic_Modules.Type
FROM         dbo.ic_ModuleInstances INNER JOIN
                      dbo.ic_Modules ON dbo.ic_ModuleInstances.ModuleId = dbo.ic_Modules.Id
GO
