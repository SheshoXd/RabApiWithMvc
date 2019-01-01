SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_ConstantListing]
AS
SELECT     dbo.ic_Constants.Id, dbo.ic_Constants.[Group], dbo.ic_Constants.Name, dbo.ic_Constants.Value, dbo.ic_Constants.Ordering, dbo.ic_Constants.IsPublished, 
                      dbo.ic_Constants.IsDeleted, dbo.ic_v_ConstantLocalization.LanguageId, dbo.ic_v_ConstantLocalization.EnglishName AS LanguageName, 
                      dbo.ic_v_ConstantLocalization.LanguageCode
FROM         dbo.ic_Constants INNER JOIN
                      dbo.ic_v_ConstantLocalization ON dbo.ic_Constants.Id = dbo.ic_v_ConstantLocalization.ConstantId

GO
