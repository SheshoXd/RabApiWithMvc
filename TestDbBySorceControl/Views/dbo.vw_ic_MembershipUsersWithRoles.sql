SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[vw_ic_MembershipUsersWithRoles]
AS
SELECT     dbo.aspnet_Membership.UserId, dbo.aspnet_Membership.PasswordFormat, dbo.aspnet_Membership.MobilePIN, dbo.aspnet_Membership.Email, 
                      dbo.aspnet_Membership.LoweredEmail, dbo.aspnet_Membership.PasswordQuestion, dbo.aspnet_Membership.PasswordAnswer, 
                      dbo.aspnet_Membership.IsApproved, dbo.aspnet_Membership.IsLockedOut, dbo.aspnet_Membership.CreateDate, 
                      dbo.aspnet_Membership.LastLoginDate, dbo.aspnet_Membership.LastPasswordChangedDate, dbo.aspnet_Membership.LastLockoutDate, 
                      dbo.aspnet_Membership.FailedPasswordAttemptCount, dbo.aspnet_Membership.FailedPasswordAttemptWindowStart, 
                      dbo.aspnet_Membership.FailedPasswordAnswerAttemptCount, dbo.aspnet_Membership.FailedPasswordAnswerAttemptWindowStart, 
                      dbo.aspnet_Membership.Comment, dbo.aspnet_Users.ApplicationId, dbo.aspnet_Users.UserName, dbo.aspnet_Users.MobileAlias, 
                      dbo.aspnet_Users.IsAnonymous, dbo.aspnet_Users.LastActivityDate, dbo.ic_UserRoles(dbo.aspnet_Users.ApplicationId, dbo.aspnet_Users.UserId) 
                      AS Roles, dbo.aspnet_Applications.ApplicationName, dbo.ic_Membership.PersonId, LTRIM(RTRIM(ISNULL(dbo.ic_Persons.FirstName, '') 
                      + ' ' + ISNULL(dbo.ic_Persons.MiddleName, '') + ' ' + ISNULL(dbo.ic_Persons.LastName, ''))) AS FullName
FROM         dbo.aspnet_Membership INNER JOIN
                      dbo.aspnet_Users ON dbo.aspnet_Membership.UserId = dbo.aspnet_Users.UserId INNER JOIN
                      dbo.aspnet_Applications ON dbo.aspnet_Membership.ApplicationId = dbo.aspnet_Applications.ApplicationId AND 
                      dbo.aspnet_Users.ApplicationId = dbo.aspnet_Applications.ApplicationId INNER JOIN
                      dbo.ic_Membership ON dbo.aspnet_Users.UserId = dbo.ic_Membership.ProvidedUserId INNER JOIN
                      dbo.ic_Persons ON dbo.ic_Membership.PersonId = dbo.ic_Persons.Id
GO
