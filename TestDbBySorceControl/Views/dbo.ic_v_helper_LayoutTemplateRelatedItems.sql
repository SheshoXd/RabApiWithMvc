SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_helper_LayoutTemplateRelatedItems]
AS
SELECT     Id, (CASE firstitemreftable WHEN 'l' THEN seconditemid ELSE firstitemid END) AS RelatedItemId, 
                      (CASE firstitemreftable WHEN 'l' THEN seconditemreftable ELSE firstitemreftable END) AS RelatedItemRefTable, 
                      (CASE firstitemreftable WHEN 'l' THEN firstitemid ELSE seconditemid END) AS LayoutTemplateId, IsDeleted
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'l') OR
                      (SecondItemRefTable = 'l')
GO
