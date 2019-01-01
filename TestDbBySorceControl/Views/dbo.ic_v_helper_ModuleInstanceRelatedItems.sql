SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE VIEW [dbo].[ic_v_helper_ModuleInstanceRelatedItems]
AS
SELECT     Id, (CASE firstitemreftable WHEN 'I' THEN seconditemid ELSE firstitemid END) AS RelatedItemId, (CASE firstitemreftable WHEN 'I' THEN seconditemreftable ELSE firstitemreftable END) 
                      AS RelatedItemRefTable, (CASE firstitemreftable WHEN 'I' THEN firstitemid ELSE seconditemid END) AS ModuleInstanceId, IsDeleted
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'I') OR
                      (SecondItemRefTable = 'I')



GO
