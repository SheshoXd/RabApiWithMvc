SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_ResourceHistories]
AS
SELECT     h.HistoryId, h.ItemId, h.Name, h.Type, h.Media, h.SourceText, h.Author, h.Notes, h.Ordering, l.Id AS LogId, l.ActionId, l.ActivityDate, l.UserId, 
                      l.Comments, l.FirstName, l.MiddleName, l.LastName, LTRIM(RTRIM(ISNULL(l.FirstName, '') + ' ' + ISNULL(l.MiddleName, '') + ' ' + ISNULL(l.LastName, 
                      ''))) AS FullName
FROM         (SELECT     Id, RefTable, RefId, RefHistoryId, ActionId, ActivityDate, UserId, Comments, FirstName, MiddleName, LastName
                       FROM          dbo.ic_v_LogsWithPersonDetails
                       WHERE      (CAST(RefTable AS VARBINARY) = CAST('r' AS VARBINARY))) AS l INNER JOIN
                      dbo.ic_ResourceHistories AS h ON l.Id = h.LogId
GO
