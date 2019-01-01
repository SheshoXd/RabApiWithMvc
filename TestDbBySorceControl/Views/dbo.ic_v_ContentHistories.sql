SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_ContentHistories]
AS
SELECT     dbo.ic_ContentHistories.HistoryId, dbo.ic_ContentHistories.ItemId, dbo.ic_ContentHistories.Title, dbo.ic_ContentHistories.DTS, dbo.ic_ContentHistories.LogId, 
                      l.ActionId, l.ActivityDate, l.UserId, l.Comments, l.FirstName, l.MiddleName, l.LastName, LTRIM(RTRIM(ISNULL(l.FirstName, '') + ' ' + ISNULL(l.MiddleName, '') 
                      + ' ' + ISNULL(l.LastName, ''))) AS FullName
FROM         (SELECT     Id, RefTable, RefId, RefHistoryId, ActionId, ActivityDate, UserId, Comments, FirstName, MiddleName, LastName
                       FROM          dbo.ic_v_LogsWithPersonDetails
                       WHERE      (RefTable = 'C')) AS l INNER JOIN
                      dbo.ic_ContentHistories ON l.Id = dbo.ic_ContentHistories.LogId
GO
