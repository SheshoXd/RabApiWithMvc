SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ext_v_BannerZoneAssets_md]
AS
SELECT     CASE FirstItemRefTable WHEN 'Z' THEN CAST(firstitemid AS int) ELSE CASE SecondItemRefTable WHEN 'Z' THEN CAST(seconditemid AS int) 
                      ELSE NULL END END AS ZoneId, CASE FirstItemRefTable WHEN 'A' THEN CAST(firstitemid AS int) 
                      ELSE CASE SecondItemRefTable WHEN 'A' THEN CAST(seconditemid AS int) ELSE NULL END END AS AssetId, dbo.GetStringParameter('Title', Id, '.') 
                      AS Title, dbo.GetIntParameter('Ordering', Id, '.') AS Ordering
FROM         dbo.ic_RelatedItems
WHERE     (FirstItemRefTable = 'A') AND (SecondItemRefTable = 'Z') OR
                      (FirstItemRefTable = 'Z') AND (SecondItemRefTable = 'A') AND (IsDeleted = 0)

GO
