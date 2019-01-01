SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mohammad J. Fathinia
-- Create date: 22-March-2011
-- Description:	Function to retrive parameter
-- =============================================
CREATE FUNCTION [dbo].[GetCharParameter] 
(
	@name varchar(60),
	@refId varchar(36),
	@refType char(1)
)
RETURNS CHAR(1)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result CHAR(1)
	
	SELECT @result = cast(value as CHAR(1)) FROM dbo.ic_Parameters WHERE RefId = @refId AND RefType = @refType AND Name = @name

	-- Return the result of the function
	RETURN @result

END
GO
