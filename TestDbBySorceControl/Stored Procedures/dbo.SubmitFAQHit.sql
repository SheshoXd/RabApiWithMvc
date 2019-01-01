SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE  PROCEDURE [dbo].[SubmitFAQHit] 
	@id int ,
	@col char,
	@reftype char 
AS

BEGIN
declare @result int=0;
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    SET NOCOUNT ON;

	    if   @col = 'v' 
				update dbo.ic_Parameters set value=ISNULL(value,0)+1 WHERE RefId = @id AND RefType =@reftype AND Name = 'ViewsCount';
        else if @col ='l' 
             	update dbo.ic_Parameters set value=ISNULL(value,0)+1 WHERE RefId = @id AND RefType = @reftype AND Name = 'LikesCount';
		

				SELECT @result = value FROM dbo.ic_Parameters WHERE RefId = @id AND RefType = @reftype AND Name = case @col when  'v' then 'ViewsCount' else 'LikesCount' end;
				

	return @result;			
END



GO
