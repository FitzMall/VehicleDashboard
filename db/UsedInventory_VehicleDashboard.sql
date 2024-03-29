USE [fitzway]
GO
/****** Object:  StoredProcedure [dbo].[UsedInventory_VehicleDashboard]    Script Date: 9/13/2023 4:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DAVID BURROUGHS
-- Create date: 9/12/2023
-- Description:	Used Inventory with Checked Out Status for Vehicle Dashboard (Vehicle Options)
-- =============================================
ALTER PROCEDURE [dbo].[UsedInventory_VehicleDashboard]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Select *, FitzWayCheckedOut = 
(SELECT CASE WHEN count([MetaDataValue7]) > 0 THEN 1 ELSE 0 END as FitzWayCheckedOut 
FROM [Checklists].[dbo].[ChecklistRecord] WHERE [MetaDataValue7] = a.V_Vin AND [Status] != 1 AND [Status] != 7) 
from [FITZWAY].dbo.[AllInventory] a where a.V_nu = 'USED' and a.V_Certified <> ''
and a.V_Certified IN ('F914','F915','F916','F917','F918','F910') AND a.V_Status in (1,2)

END
