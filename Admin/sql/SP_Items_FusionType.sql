USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Items_Category_Single]    Script Date: 06/10/2012 09:21:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Items_FusionType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Items_FusionType]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Items_Category_Single]    Script Date: 06/10/2012 09:21:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<商店信息：单个类别下的全部商品>
-- =============================================
CREATE  PROCEDURE [dbo].[SP_Items_FusionType]

AS  
 select * from Shop_Goods where [FusionType] > 350 




GO


