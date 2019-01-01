SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/*News--*/
CREATE VIEW [dbo].[ext_v_PressReleasesListing_IndexStatus]
AS
SELECT        pr.Id, pr.Title, pr.IntroText, pr.FullText, pr.ImageId, pr.DateCreated, pr.LastUpdateDate, pr.IsDeleted, pr.CurrentVersion, pr.LanguageId, pr.LanguageName, pr.LanguageCode, pr.LogId, pr.ActionId, pr.UserId, 
                         pr.Comments, pr.FirstName, pr.MiddleName, pr.LastName, pr.FullName, pr.CategoryId, pr.ItemType, pr.IsPublished, pr.SubTitle, pr.Synopsis, pr.NewsDate, pr.NewsType, pr.PublishDate, pr.ArchiveDate, 
                         pr.IsSticky, pr.IsArchived, pr.Slug, pr.FullUrl, pr.ViewsCount, idxStatus.LastUpdateDate AS LastStatusUpdateDate, idxStatus.ItemRefId, idxStatus.ItemRefTable
FROM            dbo.ext_v_PressReleasesListing AS pr LEFT OUTER JOIN
                         dbo.ic_IndexStatus AS idxStatus ON pr.Id = CAST(idxStatus.ItemRefId AS INT) AND idxStatus.ItemRefTable = 'News'
WHERE        (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'News') AND (idxStatus.LastUpdateDate IS NULL) OR
                         (idxStatus.ItemRefTable IS NULL OR
                         idxStatus.ItemRefTable = 'News') AND (pr.LastUpdateDate > idxStatus.LastUpdateDate)
GO
