SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ic_v_AlbumListing]
AS
SELECT        dbo.ic_Albums.Id, dbo.ic_Albums.Title, dbo.ic_Albums.Description, dbo.ic_Albums.CategoryId, dbo.ic_Albums.ImageId, dbo.ic_Albums.IsDefault, dbo.ic_Albums.AlbumDate, dbo.ic_Albums.DateCreated, 
                         dbo.ic_Albums.LastUpdateDate, dbo.ic_Albums.IsSticky, dbo.ic_Albums.Slug, dbo.ic_Albums.Type, dbo.ic_Albums.ItemCount, dbo.ic_Albums.IsPublished, dbo.ic_Albums.IsDeleted, dbo.ic_v_AlbumLanguages.LanguageId, 
                         dbo.ic_v_AlbumLanguages.EnglishName AS LanguageName, dbo.ic_v_AlbumLanguages.LanguageCode, dbo.ic_v_AlbumHistories.HistoryId, dbo.ic_v_AlbumHistories.LogId, dbo.ic_v_AlbumHistories.ActionId, 
                         dbo.ic_v_AlbumHistories.ActivityDate, dbo.ic_v_AlbumHistories.UserId, dbo.ic_v_AlbumHistories.UserComments, dbo.ic_v_AlbumHistories.UserFirstName, dbo.ic_v_AlbumHistories.UserMiddleName, 
                         dbo.ic_v_AlbumHistories.UserLastName, dbo.ic_v_AlbumHistories.FullName, u.FullUrl, u.ViewsCount, dbo.ic_Categories.Title AS CategoryTitle
FROM            dbo.ic_Albums INNER JOIN
                         dbo.ic_v_AlbumHistories ON dbo.ic_Albums.CurrentVersion = dbo.ic_v_AlbumHistories.HistoryId INNER JOIN
                         dbo.ic_v_AlbumLanguages ON dbo.ic_Albums.Id = dbo.ic_v_AlbumLanguages.AlbumId INNER JOIN
                             (SELECT DISTINCT CAST(ItemId AS INT) AS AlbumId, FullUrl, ViewsCount
                                FROM            dbo.ic_URLLookup
                                WHERE        (ItemType = 'g') AND (IsDeleted = 0)) AS u ON u.AlbumId = dbo.ic_Albums.Id LEFT OUTER JOIN
                         dbo.ic_Categories ON dbo.ic_Albums.CategoryId = dbo.ic_Categories.Id

GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[11] 4[51] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ic_Albums"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ic_v_AlbumHistories"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 136
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ic_v_AlbumLanguages"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 251
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ic_Categories"
            Begin Extent = 
               Top = 252
               Left = 246
               Bottom = 382
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 32
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Wi', 'SCHEMA', N'dbo', 'VIEW', N'ic_v_AlbumListing', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPane2', N'dth = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'ic_v_AlbumListing', NULL, NULL
GO
DECLARE @xp int
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'ic_v_AlbumListing', NULL, NULL
GO
