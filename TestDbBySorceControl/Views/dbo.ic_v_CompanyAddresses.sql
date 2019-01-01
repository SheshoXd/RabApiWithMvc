SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_CompanyAddresses]
AS
SELECT     dbo.ic_Companies.Id, dbo.ic_Companies.CountryId, dbo.ic_Companies.LogoId, dbo.ic_Companies.Type, dbo.ic_Companies.TradeName, dbo.ic_Companies.WorkingDays, dbo.ic_Companies.WorkingHours,
                      dbo.ic_Addresses.StreetLine1, dbo.ic_Addresses.StreetLine2, dbo.ic_Addresses.StreetLine3, dbo.ic_Addresses.City, dbo.ic_Addresses.State, 
                      dbo.ic_Addresses.Country, dbo.ic_Addresses.PostCode, dbo.ic_Addresses.ZipCode, dbo.ic_Addresses.POBox, dbo.ic_Addresses.Latitude, 
                      dbo.ic_Addresses.Longitude, dbo.ic_Addresses.Type AS AddressType, dbo.ic_CompanyAddresses.IsDefault, dbo.ic_Companies.IsDeleted, 
                      dbo.ic_v_CompanyLanguages.LanguageId, dbo.ic_v_CompanyLanguages.EnglishName, dbo.ic_v_CompanyLanguages.LanguageCode, dbo.ic_Companies.Email, 
                      dbo.ic_Companies.Website, dbo.ic_Companies.DateCreated
FROM         dbo.ic_Companies INNER JOIN
                      dbo.ic_CompanyAddresses ON dbo.ic_Companies.Id = dbo.ic_CompanyAddresses.CompanyId INNER JOIN
                      dbo.ic_Addresses ON dbo.ic_CompanyAddresses.AddressId = dbo.ic_Addresses.Id INNER JOIN
                      dbo.ic_v_CompanyLanguages ON dbo.ic_Companies.Id = dbo.ic_v_CompanyLanguages.CompanyId
GO
