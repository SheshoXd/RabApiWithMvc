SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


-- =============================================
-- Author:		Mohammad J. Fathinia
-- Create date: 9/7/2013
-- Description:	Returns a bundle of objects related to requested url
-- =============================================
CREATE PROCEDURE [dbo].[ic_sp_WebPage_SearchByUrl]
	-- Language code
	@LanguageCode VARCHAR(10) = NULL,
	
	-- Url
	@Url NVARCHAR(1000) = NULL,
	
	@DeviceType VARCHAR(3) = 'DEF',
	
	-- DEBUG MODE
	@EnableDebug bit=0
AS
BEGIN
	SET NOCOUNT ON;
    
    DECLARE @UrlLookupId UNIQUEIDENTIFIER,
			@IsDeleted BIT, @LanguageId INT, @MenuId INT, @LayoutVersionId INT, @TemplateId INT, @LayoutId INT, @ModuleInstanceId INT, @ContentId INT;
	
	IF @Url IS NULL
	BEGIN
		
		IF @EnableDebug = 1
			PRINT 'Searching for language to form URL pattern';
		
		SELECT @LanguageId = Id, @LanguageCode = LanguageCode
			FROM ic_Languages 
			WHERE IsDeleted = 0 AND ((@LanguageCode IS NOT NULL AND ((LEN(@LanguageCode) = 2 AND LEFT(LanguageCode,2) = @LanguageCode) OR LanguageCode = @LanguageCode)) OR (@LanguageCode IS NULL AND IsDefault = 1));
		
		IF @LanguageId IS NULL
			RETURN 404;
		
		-- Now find the homepage with that language code
		SET @Url = '/' + @LanguageCode + '/home';
	END
	ELSE
	BEGIN
		IF @LanguageCode IS NOT NULL AND LEN(@LanguageCode) = 2
		BEGIN
			SELECT @LanguageId = Id, @LanguageCode = LanguageCode
				FROM ic_Languages 
				WHERE IsDeleted = 0 AND LEFT(LanguageCode,2) = @LanguageCode;
			
			IF CHARINDEX('/' + LEFT(@LanguageCode, 2) + '/', @url) = 1
			BEGIN
				SET @Url = '/' + LOWER(@LanguageCode) + RIGHT(@URL, LEN(@Url) - 3);
			END			
		END
	END
	SET @Url = LOWER(LTRIM(RTRIM(@Url)));
	
    IF @EnableDebug = 1
		PRINT 'Searching for URL: ' + @Url;
	
	SELECT
		@UrlLookupId = Id,
		@MenuId = MenuId,
		@ModuleInstanceId = ModuleInstanceId,
		@IsDeleted = IsDeleted
	FROM ic_URLLookup
	WHERE FullUrl = @Url AND IsDeleted = 0
	
	IF @UrlLookupId IS NULL
	BEGIN
		DECLARE @TempLang VARCHAR(10),
			@TempMenuId INT,
			@TempItemId VARCHAR(50)
		
		IF @LanguageCode = 'ae-AE'
			SET @TempLang = 'en-GB'
		ELSE 
			SET @TempLang = 'ar-AE'

		SELECT
			@TempMenuId = MenuId,
			@TempItemId = ItemId
		FROM ic_URLLookup
		WHERE FullUrl = REPLACE(@Url, @LanguageCode, @TempLang) AND IsDeleted = 0

		IF @TempMenuId IS NOT NULL OR @TempItemId IS NOT NULL
		BEGIN
			IF @TempItemId IS NULL
				SELECT
					TOP 1
					@UrlLookupId = Id,
					@MenuId = MenuId,
					@ModuleInstanceId = ModuleInstanceId,
					@IsDeleted = IsDeleted
				FROM ic_URLLookup
				WHERE MenuId = (
					SELECT MenuId FROM ic_v_MenuLanguages WHERE GroupId = (
						SELECT GroupId FROM ic_v_MenuLanguages WHERE MenuId = @TempMenuId
					) AND LanguageId = @LanguageId
				) AND IsDeleted = 0
			ELSE
				SELECT
					TOP 1
					@UrlLookupId = Id,
					@MenuId = MenuId,
					@ModuleInstanceId = ModuleInstanceId,
					@IsDeleted = IsDeleted
				FROM ic_URLLookup
				WHERE ItemId = (
					SELECT ContentId FROM ic_v_ContentLanguages WHERE GroupId = (
						SELECT GroupId FROM ic_v_ContentLanguages WHERE ContentId = @TempItemId
					) AND LanguageId = @LanguageId
				) AND IsDeleted = 0
		END
	END
	
	IF @UrlLookupId IS NULL OR @IsDeleted = 1
		RETURN 404;
    
    IF @EnableDebug = 1
		PRINT 'Found the page with URLLookup ID: ' + CAST(@UrlLookupId as NVARCHAR(40));
	
	SELECT @LayoutId = LayoutId, @ContentId = ContentId FROM ic_Menus WHERE Id = @MenuId;
	
	IF @LanguageId IS NULL
		SELECT @LanguageId = LanguageId FROM ic_Localization WHERE RefType='L' AND RefId = CAST(@LayoutId as NVARCHAR(10));
	
	SELECT @LayoutVersionId = Id, @TemplateId = TemplateId FROM ic_LayoutTemplates WHERE LayoutId = @LayoutId AND DeviceType = @DeviceType
	
	-- return result
	SELECT * FROM ic_URLLookup WHERE Id = @UrlLookupId;
	SELECT * FROM ic_Menus WHERE Id = @MenuId;
	SELECT * FROM ic_Contents WHERE Id = ISNULL(@ContentId, -1);
	SELECT * FROM ic_Languages WHERE Id = @LanguageId;
	SELECT * FROM ic_LayoutTemplates WHERE Id = @LayoutVersionId;
	SELECT * FROM ic_Templates WHERE Id = @TemplateId;
	
	DECLARE @ModuleInstanceIds TABLE(RID UNIQUEIDENTIFIER NULL,MID INT);
	INSERT INTO @ModuleInstanceIds VALUES(NULL, @ModuleInstanceId);
	INSERT INTO @ModuleInstanceIds
	SELECT Id, CASE RelatedItemRefTable WHEN 'I' THEN CAST(RelatedItemId AS INT) ELSE NULL END FROM ic_v_helper_MenuRelatedItems WHERE RelatedItemRefTable='I' AND IsDeleted = 0 AND MenuId = @MenuId
	INSERT INTO @ModuleInstanceIds
	SELECT Id, CASE RelatedItemRefTable WHEN 'I' THEN CAST(RelatedItemId AS INT) ELSE NULL END FROM ic_v_helper_LayoutTemplateRelatedItems WHERE RelatedItemRefTable='I' AND IsDeleted = 0 AND LayoutTemplateId = @LayoutVersionId
	
	SELECT a.Id ModuleInstanceId, a.KeyValue KeyValue, a.Position DefaultPosition, a.Ordering DefaultOrdering, b.Id ModuleId, b.ControlPath ControlPath, b.IsComponent, c.RID RelatedItemId FROM ic_ModuleInstances a INNER JOIN ic_Modules b ON b.Id = ModuleId INNER JOIN @ModuleInstanceIds c on a.Id = c.MID WHERE a.IsDeleted = 0 AND a.IsPublished = 1 AND b.IsDeleted = 0 ORDER BY a.Position, a.Ordering
	
	SELECT * FROM ic_Parameters WHERE RefType='.' AND RefId IN (SELECT RID FROM @ModuleInstanceIds WHERE RID IS NOT NULL)
	
	SELECT * FROM ic_AccessLevels WHERE RefTable = 'I' AND RefId IN (SELECT MID FROM @ModuleInstanceIds WHERE MID IS NOT NULL)
	
	SELECT * FROM ic_Parameters WHERE RefType = 'I' AND RefId IN (SELECT MID FROM @ModuleInstanceIds WHERE MID IS NOT NULL);
	
	SELECT * FROM ic_Resources WHERE ResourceCode IN (SELECT RelatedItemId FROM ic_v_helper_LayoutTemplateRelatedItems WHERE RelatedItemRefTable='r' AND IsDeleted = 0 AND LayoutTemplateId = @LayoutVersionId UNION SELECT RelatedItemId FROM ic_v_helper_MenuRelatedItems WHERE RelatedItemRefTable='r' AND IsDeleted = 0 ANd MenuId = @MenuId UNION SELECT RelatedItemId FROM ic_v_helper_ModuleInstanceRelatedItems WHERE RelatedItemRefTable='r' AND IsDeleted = 0 ANd ModuleInstanceId IN (SELECT MID FROM @ModuleInstanceIds))
	
	Return 200;
END



GO
