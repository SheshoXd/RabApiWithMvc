SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_PersonWithEmail]
AS
SELECT     p.Id, p.Title, p.FirstName, p.MiddleName, p.LastName, p.Suffix, p.Nationality, p.Gender, p.DateOfBirth, p.ImageId, p.IsDeleted,
                          (SELECT     TOP (1) Address
                            FROM          dbo.ic_v_PersonInternetAddresses
                            WHERE      (PersonId = p.Id) AND (AddressType = 'E')) AS Email,
            c.Name AS NationalityTitleEn
FROM         dbo.ic_Persons AS p LEFT OUTER JOIN dbo.ic_v_ConstantListing AS c
ON p.Nationality = c.Id
GO
