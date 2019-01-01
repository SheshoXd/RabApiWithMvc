SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE FUNCTION [dbo].[GetGroupIDbyServiceID]
(
	-- Add the parameters for the function here
	@refId int
)
RETURNS nvarchar(max)
AS
BEGIN
	DECLARE @GroupID varchar(50)
	
	SELECT @GroupID = GroupId  FROM dbo.ic_Localization WHERE RefId = @refId AND RefType = 'C'

	-- Return the result of the function 
	RETURN @GroupID

END

GO
