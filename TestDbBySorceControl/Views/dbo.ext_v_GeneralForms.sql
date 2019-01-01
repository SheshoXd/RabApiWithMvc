SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_GeneralForms]
AS
SELECT     f.Id, f.Type, f.DateCreated, f.PersonId, f.TokenId, f.IsSpam, f.IsResolved, f.IsDeleted, f.IPAddress, f.IPAddress2, f.UserAgent, f.LanguageId, f.IsArchived, 
                      dbo.ic_v_PersonWithEmail.Title, dbo.ic_v_PersonWithEmail.FirstName, dbo.ic_v_PersonWithEmail.MiddleName, 
                      dbo.ic_v_PersonWithEmail.LastName, dbo.ic_v_PersonWithEmail.Suffix, dbo.ic_v_PersonWithEmail.Nationality, dbo.ic_v_PersonWithEmail.Email, 
                      dbo.GetStringParameter('Comments', f.Id, 'R') AS Comments,
                          (SELECT     COUNT(*) AS Expr1
                            FROM          dbo.ic_Parameters
                            WHERE      (RefId = f.Id) AND (RefType = 'R') AND (Name = 'Attachment')) AS AttachmentsCount, dbo.ic_v_PersonWithEmail.NationalityTitleEn, 
                      dbo.ic_Languages.EnglishName AS LanguageName, dbo.ic_Languages.LanguageCode
FROM         dbo.ext_Forms AS f INNER JOIN
                      dbo.ic_v_PersonWithEmail ON f.PersonId = dbo.ic_v_PersonWithEmail.Id INNER JOIN
                      dbo.ic_Languages ON f.LanguageId = dbo.ic_Languages.Id
GO
