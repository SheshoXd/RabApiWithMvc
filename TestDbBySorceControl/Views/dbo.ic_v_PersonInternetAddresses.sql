SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_PersonInternetAddresses]
AS
SELECT     dbo.ic_PersonInternetAddresses.PersonId, dbo.ic_PersonInternetAddresses.InternetAddressId, dbo.ic_PersonInternetAddresses.Id, 
                      dbo.ic_PersonInternetAddresses.IsDefault, dbo.ic_PersonInternetAddresses.IsDeleted, dbo.ic_InternetAddresses.Address, 
                      dbo.ic_InternetAddresses.AddressType
FROM         dbo.ic_PersonInternetAddresses INNER JOIN
                      dbo.ic_InternetAddresses ON dbo.ic_PersonInternetAddresses.InternetAddressId = dbo.ic_InternetAddresses.Id
GO
