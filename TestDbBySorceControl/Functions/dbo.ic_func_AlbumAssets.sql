SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ic_func_AlbumAssets] 
(	
	@albumId int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT     CASE FirstItemRefTable WHEN 'A' THEN CAST(seconditemid AS int) ELSE CAST(firstitemid AS int) END AS AlbumId, 
                      CASE FirstItemRefTable WHEN 'A' THEN CAST(firstitemid AS int) ELSE CAST(seconditemid AS int) END AS AssetId, dbo.GetStringParameter('Title', Id, '.') AS Title, 
                      dbo.GetIntParameter('Ordering', Id, '.') AS Ordering
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'A') AND (SecondItemRefTable = 'g') OR
                      (FirstItemRefTable = 'g') AND (SecondItemRefTable = 'A') AND (IsDeleted = 0) and ((FirstItemRefTable = 'A' and firstitemid=cast(@albumId as nvarchar(50))) or (seconditemreftable='A' and seconditemid=cast(@albumId as nvarchar(50)))) 
)
GO
