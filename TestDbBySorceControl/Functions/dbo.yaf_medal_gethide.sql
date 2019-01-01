SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[yaf_medal_gethide]
(
	@Hide bit,
	@Flags int
)
RETURNS bit
AS
BEGIN

	if ((@Flags & 4) = 0) set @Hide = 0

	return @Hide

END
GO
