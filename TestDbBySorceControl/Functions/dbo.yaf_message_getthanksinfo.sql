SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
create function [dbo].[yaf_message_getthanksinfo]
(
@MessageID INT,
@ShowThanksDate bit
) returns VARCHAR(MAX)
BEGIN
	DECLARE @Output VARCHAR(MAX)
		SELECT @Output = COALESCE(@Output+',', '') + CAST(i.ThanksFromUserID AS varchar) + 
	CASE @ShowThanksDate WHEN 1 THEN ',' + CAST (i.ThanksDate AS varchar)  ELSE '' end
			FROM	[dbo].[yaf_Thanks] i
			WHERE	i.MessageID = @MessageID	ORDER BY i.ThanksDate
	-- Add the last comma if @Output has data.
	IF @Output <> ''
		SELECT @Output = @Output + ','
	RETURN @Output
END
GO
