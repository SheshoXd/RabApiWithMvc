SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Mohammad J. Fathinia
-- Create date: 23/06/2011
-- Description:	Returns comma separated list of roles
-- =============================================
CREATE FUNCTION [dbo].[ic_UserRoles] 
(
	-- Add the parameters for the function here
	@ApplicationId uniqueidentifier,
    @UserId         uniqueidentifier
)
RETURNS varchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(max)
        
    SELECT @Result = COALESCE(@Result+',' ,'') + r.RoleName
    FROM   dbo.aspnet_Roles r, dbo.aspnet_UsersInRoles ur
    WHERE  r.RoleId = ur.RoleId AND r.ApplicationId = @ApplicationId AND ur.UserId = @UserId
    ORDER BY r.RoleName
	-- Return the result of the function
	RETURN @Result
END
GO
