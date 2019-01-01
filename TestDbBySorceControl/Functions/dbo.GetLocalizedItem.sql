SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[GetLocalizedItem]
(
	@RefId VARCHAR(50),
	@RefType CHAR(1),
	@LanguageId INT
)
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @Result VARCHAR(50)
	SELECT	@Result = RefId
    FROM dbo.ic_Localization
    WHERE GroupId =
            (
				SELECT GroupId
				FROM dbo.ic_Localization
				WHERE RefType = @RefType AND RefId = @RefId
			)	
			AND LanguageId = @LanguageId
	RETURN @Result
END
GO
