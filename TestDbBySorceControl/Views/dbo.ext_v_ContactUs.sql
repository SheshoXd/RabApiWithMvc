SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ext_v_ContactUs]
AS
SELECT        f.Id, f.Type, f.TokenId, f.DateCreated, f.PersonId, f.IsResolved, f.IsDeleted, 
                        f.LanguageId, f.IsArchived, dbo.ic_v_PersonWithEmail.FirstName, dbo.ic_v_PersonWithEmail.MiddleName, 
                         dbo.ic_v_PersonWithEmail.LastName, 
                         dbo.ic_v_PersonWithEmail.Suffix, dbo.ic_v_PersonWithEmail.Nationality,
						  dbo.ic_v_PersonWithEmail.Email, dbo.GetDateParameter('LastUpdateDate', f.Id, N'R') AS LastUpdateDate,
						   dbo.GetStringParameter('Subject', f.Id, N'R') 
                         AS Subject, dbo.GetStringParameter('CompanyName', f.Id, N'R') AS CompanyName, 
						  dbo.GetStringParameter('Comment', f.Id, N'R') AS Comment, dbo.GetStringParameter('Attachment', f.Id, N'R') AS Attachment,
						  dbo.ic_v_PersonWithEmail.NationalityTitleEn, dbo.ic_Languages.EnglishName AS LanguageName, dbo.ic_Languages.LanguageCode
                        
FROM            dbo.ext_Forms AS f INNER JOIN
                         dbo.ic_v_PersonWithEmail ON f.PersonId = dbo.ic_v_PersonWithEmail.Id INNER JOIN
                         dbo.ic_Languages ON f.LanguageId = dbo.ic_Languages.Id
WHERE        (f.Type = 'U')

GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "f"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ic_v_PersonWithEmail"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ic_Languages"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 467
               Bottom = 136
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 24
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
', 'SCHEMA', N'dbo', 'VIEW', N'ext_v_ContactUs', NULL, NULL
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'ext_v_ContactUs', NULL, NULL
GO
