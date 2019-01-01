SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_MenuHistories]
AS
SELECT     dbo.ic_MenuHistories.HistoryId, dbo.ic_MenuHistories.ItemId, dbo.ic_MenuHistories.Name, dbo.ic_MenuHistories.ShortName, dbo.ic_MenuHistories.Title, 
                      l.Id AS LogId, l.ActionId, l.ActivityDate, l.UserId, l.Comments, l.FirstName, l.MiddleName, l.LastName, LTRIM(RTRIM(ISNULL(l.FirstName, '') 
                      + ' ' + ISNULL(l.MiddleName, '') + ' ' + ISNULL(l.LastName, ''))) AS FullName
FROM         (SELECT     Id, RefTable, RefId, RefHistoryId, ActionId, ActivityDate, UserId, Comments, FirstName, MiddleName, LastName
                       FROM          dbo.ic_v_LogsWithPersonDetails
                       WHERE      (RefTable = 'P')) AS l INNER JOIN
                      dbo.ic_MenuHistories ON l.Id = dbo.ic_MenuHistories.LogId
GO
