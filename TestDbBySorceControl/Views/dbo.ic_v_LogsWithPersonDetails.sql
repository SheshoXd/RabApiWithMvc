SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_LogsWithPersonDetails]
AS
SELECT     dbo.ic_Logs.Id, dbo.ic_Logs.RefTable, dbo.ic_Logs.RefId, dbo.ic_Logs.RefHistoryId, dbo.ic_Logs.ActionId, dbo.ic_Logs.ActivityDate, dbo.ic_Logs.UserId, 
                      dbo.ic_Logs.Comments, dbo.ic_Persons.FirstName, dbo.ic_Persons.MiddleName, dbo.ic_Persons.LastName
FROM         dbo.ic_Logs INNER JOIN
                      dbo.ic_Persons ON dbo.ic_Logs.UserId = dbo.ic_Persons.Id
GO
