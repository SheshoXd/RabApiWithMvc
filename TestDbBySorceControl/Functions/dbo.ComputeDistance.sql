SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mahmoud Barakat
-- Create date: 30-9-2013
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ComputeDistance](
	-- Add the parameters for the function here
	@Latitude1 FLOAT = NULL, -- station coordinate
	@Longitude1 FLOAT  = NULL, -- station coordinate
	@Latitude2 FLOAT   = NULL, -- current coordinate
	@Longitude2 FLOAT  = NULL, -- current coordinate
	@Unit	char = 'K'
)
RETURNS float
AS
BEGIN
	DECLARE @THETA FLOAT
	SET @THETA = @Longitude1 - @Longitude2
	
	DECLARE @DIST  FLOAT 
	SET @DIST = SIN(@Latitude1 * PI() / 180.0)  *  SIN(@Latitude2 * PI() / 180.0) + COS(@Latitude1 * PI() / 180.0) * COS(@Latitude2 * PI() / 180.0) * COS(@THETA * PI() / 180.0)
	SET @DIST = ACOS(@DIST)
	SET @DIST = @DIST / PI() * 180.0
	SET @DIST = @DIST * 60 * 1.1515;
	
	IF (@Unit = 'k')
		SET @DIST = @DIST * 1.609344
		
	ELSE IF (@Unit = 'N')	
		SET @DIST = @DIST * 0.8684
    
    RETURN @DIST; 
END



GO
