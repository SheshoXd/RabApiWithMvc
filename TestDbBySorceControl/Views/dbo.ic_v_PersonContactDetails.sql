SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_PersonContactDetails]
AS
SELECT     dbo.ic_PersonContactNumbers.PersonId, dbo.ic_PersonContactNumbers.ContactNumberId, dbo.ic_PersonContactNumbers.IsDeleted, 
                      dbo.ic_PersonContactNumbers.IsDefault, dbo.ic_ContactNumbers.CountryCode, dbo.ic_ContactNumbers.CityCode, dbo.ic_ContactNumbers.Number, 
                      dbo.ic_ContactNumbers.Extension, dbo.ic_ContactNumbers.MediaType, dbo.ic_ContactNumbers.Type, dbo.ic_PersonContactNumbers.Id
FROM         dbo.ic_ContactNumbers INNER JOIN
                      dbo.ic_PersonContactNumbers ON dbo.ic_ContactNumbers.Id = dbo.ic_PersonContactNumbers.ContactNumberId
GO
