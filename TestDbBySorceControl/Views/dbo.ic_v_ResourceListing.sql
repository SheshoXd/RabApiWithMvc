SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_ResourceListing]
AS
SELECT     r.ResourceCode, r.Name, r.Type, r.Media, r.LastUpdateDate, r.SourceText, r.Author, r.Notes, r.IsPublished, r.IsDeleted, r.CurrentVersion, r.Ordering, 
                      h.LogId, h.ActionId, h.ActivityDate, h.UserId, h.Comments, h.FirstName, h.MiddleName, h.LastName, h.FullName
FROM         dbo.ic_Resources AS r INNER JOIN
                      dbo.ic_v_ResourceHistories AS h ON r.CurrentVersion = h.HistoryId
GO
