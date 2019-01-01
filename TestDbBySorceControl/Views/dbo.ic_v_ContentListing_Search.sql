SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_ContentListing_Search]
AS
SELECT        Title, LanguageId, IsPublished, IsDeleted
FROM            dbo.ic_v_ContentListing

UNION 

 SELECT       [Title] ,[LanguageId] ,[IsPublished] ,[IsDeleted]
 FROM         [dbo].[ic_v_AlbumListing] WHERE [Type] ='P'

UNION

SELECT [OriginalTitle],[LanguageId],[IsPublished],[IsDeleted]
FROM [dbo].[ic_v_AlbumAssetList] where albumid in (629,634)

GO
