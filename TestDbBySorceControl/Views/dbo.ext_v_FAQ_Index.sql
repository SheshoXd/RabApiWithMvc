SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ext_v_FAQ_Index]
AS
SELECT fq.*
	, idxStatus.LastUpdateDate as 'LastStatusUpdateDate'
	, idxStatus.ItemRefId, idxStatus.ItemRefTable
from [dbo].[ext_v_FAQ] fq
LEFT JOIN ic_IndexStatus idxStatus ON fq.Id =  CAST(idxStatus.ItemRefId AS INT)  
WHERE (idxStatus.ItemRefTable is NULL OR idxStatus.ItemRefTable = 'FAQ')
AND (idxStatus.LastUpdateDate is NULL OR fq.LastUpdateDate > idxStatus.LastUpdateDate)

GO
