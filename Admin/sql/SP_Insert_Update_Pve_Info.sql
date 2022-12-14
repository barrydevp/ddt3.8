USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_Pve_Info]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_Pve_Info]
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
CREATE PROCEDURE [dbo].[SP_Insert_Update_Pve_Info] 
		   @ID int,
           @Name nvarchar(100),
           @Type int,
           @LevelLimits int,
           @SimpleTemplateIds nvarchar(1024),
           @NormalTemplateIds nvarchar(1024),
           @HardTemplateIds nvarchar(1024),
           @TerrorTemplateIds nvarchar(1024),
           @Pic nvarchar(100),
           @Description nvarchar(1024),
           @SimpleGameScript nvarchar(100),
           @NormalGameScript nvarchar(100),
           @HardGameScript nvarchar(100),
           @TerrorGameScript nvarchar(100),
           @Ordering int,
           @AdviceTips nvarchar(100),
           @setUpdate int
AS

declare @count int

select @count= isnull(count(*),0) from [Pve_Info] where ID = @ID
if (@count <> 0 and @setUpdate = 0)
begin
UPDATE [Db_Tank].[dbo].[Pve_Info]
   SET [ID] = @ID
      ,[Name] = @Name
      ,[Type] = @Type
      ,[LevelLimits] = @LevelLimits
      ,[SimpleTemplateIds] = @SimpleTemplateIds
      ,[NormalTemplateIds] = @NormalTemplateIds
      ,[HardTemplateIds] = @HardTemplateIds
      ,[TerrorTemplateIds] = @TerrorTemplateIds
      ,[Pic] = @Pic
      ,[Description] = @Description
      ,[SimpleGameScript] = @SimpleGameScript
      ,[NormalGameScript] = @NormalGameScript
      ,[HardGameScript] = @HardGameScript
      ,[TerrorGameScript] = @TerrorGameScript
      ,[Ordering] = @Ordering
      ,[AdviceTips] = @AdviceTips
 WHERE [ID] = @ID
return 1  
end
--add Game_Map
else 
begin
INSERT INTO [Db_Tank].[dbo].[Pve_Info]
           ([ID]
           ,[Name]
           ,[Type]
           ,[LevelLimits]
           ,[SimpleTemplateIds]
           ,[NormalTemplateIds]
           ,[HardTemplateIds]
           ,[TerrorTemplateIds]
           ,[Pic]
           ,[Description]
           ,[SimpleGameScript]
           ,[NormalGameScript]
           ,[HardGameScript]
           ,[TerrorGameScript]
           ,[Ordering]
           ,[AdviceTips])
     VALUES
           (@ID,
           @Name,
           @Type,
           @LevelLimits,
           @SimpleTemplateIds,
           @NormalTemplateIds,
           @HardTemplateIds,
           @TerrorTemplateIds,
           @Pic,
           @Description,
           @SimpleGameScript,
           @NormalGameScript,
           @HardGameScript,
           @TerrorGameScript,
           @Ordering,
           @AdviceTips)
           
return 0
           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


