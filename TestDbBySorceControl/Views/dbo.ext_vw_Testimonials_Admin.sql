SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_vw_Testimonials_Admin]
AS
SELECT        Id, Title AS Name, DateCreated, LastUpdateDate, IsDeleted, CurrentVersion, LanguageId, LanguageName, LanguageCode, LogId, ActionId, UserId, Comments, FullName, CategoryId, ItemType, IsPublished, 
                         dbo.GetStringParameter('Designation', Id, 'C') AS Designation, dbo.GetStringParameter('Organization', Id, 'C') AS Organization, dbo.GetDateParameter('ItemDate', Id, 'C') AS ItemDate, 
                         dbo.GetBitParameter('IsSticky', Id, 'C') AS IsSticky
FROM            dbo.ic_v_ContentListing AS c
WHERE        (ItemType = 't')

GO
