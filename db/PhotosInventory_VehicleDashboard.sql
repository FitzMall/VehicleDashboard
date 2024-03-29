USE [fitzway]
GO
/****** Object:  StoredProcedure [dbo].[PhotosInventory_VehicleDashboard]    Script Date: 9/13/2023 10:10:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DAVID BURROUGHS
-- Create date: 9/13/2023
-- Description:	Photos in Inventory for Vehicle Dashboard (Vehicle Options)
-- =============================================
ALTER PROCEDURE [dbo].[PhotosInventory_VehicleDashboard]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;
	SELECT COUNT([Id]) as Images
      ,[VIN]
  FROM [442198-DB1].[FITZWAY].[dbo].[FM_HomeNetImages]
  group by VIN

	  EXEC	 [442198-DB1].[FITZWAY].[dbo].[GetPhotoNumberByVIN]

END
