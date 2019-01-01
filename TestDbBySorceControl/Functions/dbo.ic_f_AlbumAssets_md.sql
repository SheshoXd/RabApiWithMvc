SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ic_f_AlbumAssets_md] 
(
	
)
RETURNS 
@AlbumAssets TABLE 
(
	-- Add the column definitions for the TABLE variable here
	AlbumId int, 
	AssetId int,
	Title nvarchar(max),
	Ordering int
)
AS
BEGIN
	
	WITH ALBUM_ASSET(AlbumId,AssetId,Title,Ordering) AS (
	-- Fill the table variable with the rows for your result set
	SELECT     CASE FirstItemRefTable WHEN 'g' THEN CAST(Firstitemid AS int) ELSE CASE SecondItemRefTable WHEN 'g' THEN CAST(seconditemid AS int) ELSE NULL 
                      END END AS AlbumId, CASE FirstItemRefTable WHEN 'A' THEN CAST(firstitemid AS int) ELSE CASE SecondItemRefTable WHEN 'A' THEN CAST(seconditemid AS int) 
                      ELSE NULL END END AS AssetId, dbo.GetStringParameter('Title', Id, '.') AS Title, dbo.GetIntParameter('Ordering', Id, '.') AS Ordering
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'A') AND (SecondItemRefTable = 'g') AND (IsDeleted = 0) OR
                      (FirstItemRefTable = 'g') AND (SecondItemRefTable = 'A') AND (IsDeleted = 0)
	
                      )
    INSERT @AlbumAssets
    SELECT AlbumId,AssetId,Title,Ordering
    FROM ALBUM_ASSET
	RETURN 
END
GO
