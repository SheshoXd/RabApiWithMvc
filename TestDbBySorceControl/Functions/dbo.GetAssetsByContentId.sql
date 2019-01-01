SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE FUNCTION [dbo].[GetAssetsByContentId] (@ContentId INT)
RETURNS nvarchar(max)
AS
BEGIN

DECLARE @result nvarchar(max);



 with temp as (
  select asse.id,asse.Size,asse.OriginalFileName,asse.GeneratedFileName,asse.MimeType from dbo.ic_assets as asse 
  inner  JOIN dbo.ic_RelatedItems as rt  on rt.SecondItemId=asse.id and rt.SecondItemRefTable ='A' and rt.FirstItemRefTable='C'
  where  @ContentId=rt.FirstItemId  and (rt.isdeleted <>1 )
							  
) 

   SELECT @result =  stuff((select ';' + CONVERT(varchar(100), id)+','+ MimeType +','+CONVERT(varchar(1000),Size)+','+OriginalFileName+','+GeneratedFileName from temp b  for xml path('')), 1, 2, '') 
   RETURN @result


END;


GO
