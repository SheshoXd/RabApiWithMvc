SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE FUNCTION [dbo].[usp_ClearHTMLTags] 
    (@String NVARCHAR(MAX)) 
     
    RETURNS NVARCHAR(MAX) 
    AS 
    BEGIN 
        DECLARE @Start INT, 
                @End INT, 
                @Length INT 
         
        WHILE CHARINDEX('<', @String) > 0 AND CHARINDEX('>', @String, CHARINDEX('<', @String)) > 0 
        BEGIN 
            SELECT  @Start  = CHARINDEX('<', @String),  
                    @End    = CHARINDEX('>', @String, CHARINDEX('<', @String)) 
            SELECT @Length = (@End - @Start) + 1 
             
            IF @Length > 0 
            BEGIN 
                SELECT @String = STUFF(@String, @Start, @Length, '') 
             END 
         END 
         
        RETURN @String 
    END 
GO
