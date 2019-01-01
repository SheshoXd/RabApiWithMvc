SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
/****** Exist in the live data base and not exist in the staging database ******/
create VIEW [dbo].[ic_v_NewsletterEmails]
AS
SELECT  distinct FirstName, Email
FROM            dbo.ic_v_PersonWithEmail
WHERE        (Id IN
                             (SELECT        PersonId
                               FROM            dbo.ext_Forms
                               WHERE        (Type = 'N')))


GO
