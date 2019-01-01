SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_helper_MenuRelatedItems]
AS
SELECT     Id, (CASE firstitemreftable WHEN 'P' THEN seconditemid ELSE firstitemid END) AS RelatedItemId, 
                      (CASE firstitemreftable WHEN 'P' THEN seconditemreftable ELSE firstitemreftable END) AS RelatedItemRefTable, 
                      (CASE firstitemreftable WHEN 'P' THEN firstitemid ELSE seconditemid END) AS MenuId, IsDeleted
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'P') OR
                      (SecondItemRefTable = 'P')
GO
