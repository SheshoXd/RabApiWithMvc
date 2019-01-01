SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mohammad J. Fathinia
-- Create date: 22-March-2011
-- Description:	Function to retrive parameter
-- =============================================
CREATE FUNCTION [dbo].[GetStringParameter] 
(
	@name varchar(60),
	@refId varchar(36),
	@refType char(1)
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result nvarchar(max)
	
	SELECT @result = value FROM dbo.ic_Parameters WHERE RefId = @refId AND RefType = @refType AND Name = @name

	-- Return the result of the function
	RETURN @result

END
GO
