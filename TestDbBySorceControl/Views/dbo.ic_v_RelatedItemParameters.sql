SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_RelatedItemParameters]
AS
SELECT     p.Name, p.Value, p.IsPublished, p.IsDeleted, dbo.ic_RelatedItems.FirstItemId, dbo.ic_RelatedItems.FirstItemRefTable, dbo.ic_RelatedItems.SecondItemId, 
                      dbo.ic_RelatedItems.SecondItemRefTable, dbo.ic_RelatedItems.Id AS RelatedItemId
FROM         (SELECT     Id, RefId, RefType, Name, Value, IsPublished, IsDeleted, CurrentVersion
                       FROM          dbo.ic_Parameters
                       WHERE      (RefType = '.')) AS p INNER JOIN
                      dbo.ic_RelatedItems ON p.RefId = dbo.ic_RelatedItems.Id
GO
