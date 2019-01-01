SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[yaf_medal_getribbonsetting]
(
	@RibbonURL nvarchar(250),
	@Flags int,
	@OnlyRibbon bit
)
RETURNS bit
AS
BEGIN

	if ((@RibbonURL is null) or ((@Flags & 2) = 0)) set @OnlyRibbon = 0

	return @OnlyRibbon

END
GO
