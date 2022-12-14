USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_Item_Fusion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_Item_Fusion]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<公会信息：加入一条用户申请结婚信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Update_Item_Fusion] 
		   @FusionID int,
           @Item1 int,
           @Item2 int,
           @Item3 int,
           @Item4 int,
           @Formula int,
           @Reward int,
           @setUpdate int
AS

declare @count int

select @count= isnull(count(*),0) from [Item_Fusion] where [FusionID] = @FusionID
if (@count <> 0 and @setUpdate = 0)
begin
UPDATE [Db_Tank].[dbo].[Item_Fusion]
   SET [FusionID] = @FusionID
      ,[Item1] = @Item1
      ,[Item2] = @Item2
      ,[Item3] = @Item3
      ,[Item4] = @Item4
      ,[Formula] = @Formula
      ,[Reward] = @Reward
 WHERE [FusionID] = @FusionID
return 1  
end
--add Game_Map
else 
begin
INSERT INTO [Db_Tank].[dbo].[Item_Fusion]
           ([FusionID]
           ,[Item1]
           ,[Item2]
           ,[Item3]
           ,[Item4]
           ,[Formula]
           ,[Reward])
     VALUES
           (@FusionID
           ,@Item1
           ,@Item2
           ,@Item3
           ,@Item4
           ,@Formula
           ,@Reward)
           
return 0
           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


