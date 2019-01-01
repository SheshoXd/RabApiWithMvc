SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[GetCategoryParentsIds] (@cateId INT)
RETURNS nvarchar(max)
AS
BEGIN

DECLARE @result nvarchar(max);



 with temp as (
   select id, parentid, title
   from ic_Categories
   where id =@cateId 
   union all
   select c.id, c.parentid, c.title
   from ic_Categories c
     join temp p on p.parentid = c.id  
) 

   SELECT @result =  stuff((select ', ' + CONVERT(varchar(100), id) from temp b   where  b.id<>@cateId for xml path('')), 1, 2, '') 
   RETURN @result


END;
GO
