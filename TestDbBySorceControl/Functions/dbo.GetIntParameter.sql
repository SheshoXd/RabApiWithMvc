SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[GetIntParameter] 
(
	@name varchar(60),
	@refId varchar(36),
	@refType char(1)
)
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result INT
	
	SELECT @result = cast((CASE WHEN LEN(RTRIM(LTRIM(value))) = 0 OR value IS NULL THEN NULL ELSE value END) as INT) FROM dbo.ic_Parameters WHERE RefId = @refId AND RefType = @refType AND Name = @name

	-- Return the result of the function
	RETURN @result

END
GO
