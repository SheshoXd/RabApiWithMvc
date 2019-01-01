SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[GetDateParameter] 
(
	@name varchar(60),
	@refId varchar(36),
	@refType nchar(1)
)
RETURNS DateTime
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result DateTime
	
	SELECT @result = convert(datetime, (CASE WHEN LEN(RTRIM(LTRIM(value))) = 0 OR value IS NULL THEN NULL ELSE value END) ,101) FROM dbo.ic_Parameters WHERE RefId = @refId AND RefType = @refType AND Name = @name

	-- Return the result of the function
	RETURN @result
END
GO
