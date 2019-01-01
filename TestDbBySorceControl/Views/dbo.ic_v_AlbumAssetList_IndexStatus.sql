SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_AlbumAssetList_IndexStatus]
AS
SELECT        al.OriginalTitle AS Title, al.Type, al.MimeType, al.ImageId, al.DateCreated, al.LastUpdateDate, al.Size, al.OriginalFileName, al.GeneratedFileName, al.IsSticky, al.IsPublished, al.IsDeleted, al.DownloadCounter, al.ItemDate, al.Id, 
                         al.LanguageId, al.LanguageName, al.LanguageCode, al.AlbumId, al.Ordering, al.Description, al.EmbedCode, al.Slug, al.CategoryId
FROM            dbo.ic_v_AlbumAssetList AS al LEFT OUTER JOIN
                         dbo.ic_IndexStatus AS idxStatus ON al.Id = CAST(idxStatus.ItemRefId AS INT) AND idxStatus.ItemRefTable = 'Albums'
WHERE        (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Albums') AND (idxStatus.LastUpdateDate IS NULL) OR
                         (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Albums') AND (al.LastUpdateDate > idxStatus.LastUpdateDate)

GO
