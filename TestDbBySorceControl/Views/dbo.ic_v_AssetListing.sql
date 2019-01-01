SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ic_v_AssetListing]
AS
SELECT     Id, Title, Description, Type, MimeType, ImageId, DateCreated, Size, OriginalFileName, GeneratedFileName, IsDeleted, LastUpdateDate, IsPublished, 
                      DownloadCounter, IsSticky, ItemDate
FROM         dbo.ic_Assets
GO
