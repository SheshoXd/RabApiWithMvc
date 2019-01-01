SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_vw_Testimonials_User]
AS
SELECT        c.Id, c.Title AS Name, c.DateCreated, c.LastUpdateDate, c.IsDeleted, cl.LanguageId, c.CategoryId, c.ItemType, c.IsPublished, dbo.GetStringParameter('Designation', c.Id, 'C') AS Designation, 
                         dbo.GetStringParameter('Organization', c.Id, 'C') AS Organization, dbo.GetDateParameter('ItemDate', c.Id, 'C') AS ItemDate, dbo.GetBitParameter('IsSticky', c.Id, 'C') AS IsSticky, c.ImageId, c.FullText, 
                         c.IntroText
FROM            dbo.ic_Contents AS c INNER JOIN
                         dbo.ic_v_ContentLanguages AS cl ON c.Id = cl.ContentId
WHERE        (c.ItemType = 't')

GO
