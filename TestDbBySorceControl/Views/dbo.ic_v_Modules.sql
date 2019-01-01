SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE VIEW [dbo].[ic_v_Modules]
AS
SELECT     dbo.ic_Modules.ID , dbo.ic_Modules.ControlPath, dbo.ic_Modules.Description, dbo.ic_Modules.IsAdmin , 
                      dbo.ic_Modules.IsComponent, dbo.ic_Modules.IsDeleted, dbo.ic_Modules.IsPageDependent, dbo.ic_Modules.RefTypeCanHandle, 
                      dbo.ic_Modules.Title, dbo.ic_Modules.Type
FROM         dbo.ic_Modules


GO
