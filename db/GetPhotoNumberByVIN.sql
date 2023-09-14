USE [FITZWAY]
GO
/****** Object:  StoredProcedure [dbo].[GetPhotoNumberByVIN]    Script Date: 9/14/2023 9:39:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DAVID BURROUGHS
-- Create date: 9/13/2023
-- Description:	Photos in Inventory for Vehicle Dashboard (Vehicle Options)
-- =============================================
ALTER PROCEDURE [dbo].[GetPhotoNumberByVIN]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT COUNT([Id]) as ImagesSum
      ,[VIN]
  FROM [FITZWAY].[dbo].[FM_HomeNetImages]
  group by VIN
  END
