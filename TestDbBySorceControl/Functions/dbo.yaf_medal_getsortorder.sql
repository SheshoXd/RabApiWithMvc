SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[yaf_medal_getsortorder]
(
	@SortOrder tinyint,
	@DefaultSortOrder tinyint,
	@Flags int
)
RETURNS tinyint
AS
BEGIN

	if ((@Flags & 8) = 0) set @SortOrder = @DefaultSortOrder

	return @SortOrder

END
GO
