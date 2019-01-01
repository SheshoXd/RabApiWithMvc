SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_CompanyContactNumbers]
AS
SELECT     dbo.ic_Companies.Id, dbo.ic_Companies.TradeName, dbo.ic_Companies.CountryId, dbo.ic_Companies.LogoId, dbo.ic_Companies.IsDeleted, dbo.ic_Companies.Type, dbo.ic_Companies.WorkingDays, dbo.ic_Companies.WorkingHours,
                      dbo.ic_ContactNumbers.CountryCode, dbo.ic_ContactNumbers.CityCode, dbo.ic_ContactNumbers.Number, dbo.ic_ContactNumbers.Extension, 
                      dbo.ic_ContactNumbers.MediaType, dbo.ic_ContactNumbers.Type AS ContactType, dbo.ic_CompanyContactNumbers.IsDefault, 
                      dbo.ic_v_CompanyLanguages.LanguageId, dbo.ic_v_CompanyLanguages.EnglishName, dbo.ic_v_CompanyLanguages.LanguageCode, dbo.ic_Companies.Email, 
                      dbo.ic_Companies.Website, dbo.ic_Companies.DateCreated
FROM         dbo.ic_Companies INNER JOIN
                      dbo.ic_v_CompanyLanguages ON dbo.ic_Companies.Id = dbo.ic_v_CompanyLanguages.CompanyId INNER JOIN
                      dbo.ic_CompanyContactNumbers ON dbo.ic_Companies.Id = dbo.ic_CompanyContactNumbers.CompanyId INNER JOIN
                      dbo.ic_ContactNumbers ON dbo.ic_CompanyContactNumbers.ContactNumberId = dbo.ic_ContactNumbers.Id
GO
