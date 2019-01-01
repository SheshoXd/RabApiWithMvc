SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_AlbumAssets_md]
AS
SELECT     CASE FirstItemRefTable WHEN 'A' THEN CAST(seconditemid AS int) ELSE CAST(firstitemid AS int) END AS AlbumId, 
                      CASE FirstItemRefTable WHEN 'A' THEN CAST(firstitemid AS int) ELSE CAST(seconditemid AS int) END AS AssetId, dbo.GetStringParameter('Title', Id, '.') 
                      AS Title, dbo.GetIntParameter('Ordering', Id, '.') AS Ordering
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'A') AND (SecondItemRefTable = 'g') OR
                      (FirstItemRefTable = 'g') AND (SecondItemRefTable = 'A') AND (IsDeleted = 0)
GO
