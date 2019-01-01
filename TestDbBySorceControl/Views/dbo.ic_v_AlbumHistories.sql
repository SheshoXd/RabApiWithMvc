SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_AlbumHistories]
AS
SELECT     a.HistoryId, a.ItemId, a.Title, a.LogId, a.DTS, l.ActionId, l.ActivityDate, l.UserId, l.Comments AS UserComments, l.FirstName AS UserFirstName, 
                      l.MiddleName AS UserMiddleName, l.LastName AS UserLastName, LTRIM(RTRIM(ISNULL(l.FirstName, '') + ' ' + ISNULL(l.MiddleName, '') + ' ' + ISNULL(l.LastName, 
                      ''))) AS FullName
FROM         (SELECT     Id, RefTable, RefId, RefHistoryId, ActionId, ActivityDate, UserId, Comments, FirstName, MiddleName, LastName
                       FROM          dbo.ic_v_LogsWithPersonDetails
                       WHERE      (RefTable = 'g')) AS l INNER JOIN
                      dbo.ic_AlbumHistories AS a ON l.Id = a.LogId
GO
