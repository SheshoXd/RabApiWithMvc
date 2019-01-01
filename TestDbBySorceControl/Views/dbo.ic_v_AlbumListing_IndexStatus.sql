SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/*Album--*/
CREATE VIEW [dbo].[ic_v_AlbumListing_IndexStatus]
AS
SELECT        al.Id, al.Title, al.Description, al.CategoryId, al.ImageId, al.AlbumDate, al.DateCreated, al.LastUpdateDate, al.IsSticky, al.Slug, al.Type, al.ItemCount, al.IsPublished, al.IsDeleted, al.LanguageId, al.LanguageName, 
                         al.LanguageCode, al.HistoryId, al.LogId, al.ActionId, al.ActivityDate, al.UserId, al.UserComments, al.UserFirstName, al.UserMiddleName, al.UserLastName, al.FullName, al.FullUrl, al.ViewsCount, al.CategoryTitle, 
                         idxStatus.LastUpdateDate AS LastStatusUpdateDate, idxStatus.ItemRefId, idxStatus.ItemRefTable
FROM            dbo.ic_v_AlbumListing AS al LEFT OUTER JOIN
                         dbo.ic_IndexStatus AS idxStatus ON al.Id = CAST(idxStatus.ItemRefId AS INT) AND idxStatus.ItemRefTable = 'Albums'
WHERE        (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Albums') AND (idxStatus.LastUpdateDate IS NULL) OR
                         (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'Albums') AND (al.LastUpdateDate > idxStatus.LastUpdateDate)
GO
