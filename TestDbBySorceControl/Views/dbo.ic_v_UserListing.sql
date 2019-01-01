SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_UserListing]
AS
SELECT     dbo.ic_Membership.PersonId, dbo.ic_Persons.Title, dbo.ic_Persons.FirstName, dbo.ic_Persons.MiddleName, dbo.ic_Persons.LastName, dbo.ic_Persons.Suffix, 
                      dbo.ic_Membership.IsDeleted, dbo.aspnet_Users.UserId, dbo.aspnet_Users.UserName, dbo.aspnet_Users.LastActivityDate, dbo.aspnet_Membership.Email, 
                      dbo.aspnet_Membership.IsApproved, dbo.aspnet_Membership.IsLockedOut
FROM         dbo.ic_Membership INNER JOIN
                      dbo.aspnet_Users ON dbo.ic_Membership.Id = dbo.aspnet_Users.UserId INNER JOIN
                      dbo.ic_Persons ON dbo.ic_Membership.PersonId = dbo.ic_Persons.Id INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId
GO
