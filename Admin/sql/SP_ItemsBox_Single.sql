USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Items_Single]    Script Date: 06/07/2012 10:57:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ItemsBox_Single]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ItemsBox_Single]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Items_Single]    Script Date: 06/07/2012 10:57:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<商店信息：获取一条商品信息>
-- =============================================
CREATE  PROCEDURE [dbo].[SP_ItemsBox_Single]
@ID int
AS  
 select * from [Shop_Goods_Box] where [DataId]=@ID

GO


