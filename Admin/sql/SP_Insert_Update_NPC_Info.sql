USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_NPC_Info]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_NPC_Info]
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
CREATE PROCEDURE [dbo].[SP_Insert_Update_NPC_Info] 
		   @ID int,
           @Name nvarchar(50),
           @Level int,
           @Camp int,
           @Type int,
           @X int,
           @Y int,
           @Width int,
           @Height int,
           @Blood int,
           @MoveMin int,
           @MoveMax int,
           @BaseDamage int,
           @BaseGuard int,
           @Defence int,
           @Agility int,
           @Lucky int,
           @Attack int,
           @ModelID nvarchar(1000),
           @ResourcesPath nvarchar(1000),
           @DropRate nvarchar(50),
           @Experience int,
           @Delay int,
           @Immunity int,
           @Alert int,
           @Range int,
           @Preserve int,
           @Script nvarchar(50),
           @FireX int,
           @FireY int,
           @DropId int,
           @setUpdate int
AS

declare @count int

select @count= isnull(count(*),0) from [NPC_Info] where ID = @ID
if (@count <> 0 and @setUpdate = 0)
begin
UPDATE [Db_Tank].[dbo].[NPC_Info]
   SET [ID] = @ID
      ,[Name] = @Name
      ,[Level] = @Level
      ,[Camp] = @Camp
      ,[Type] = @Type
      ,[X] = @X
      ,[Y] = @Y
      ,[Width] = @Width
      ,[Height] = @Height
      ,[Blood] = @Blood
      ,[MoveMin] = @MoveMin
      ,[MoveMax] = @MoveMax
      ,[BaseDamage] = @BaseDamage
      ,[BaseGuard] = @BaseGuard
      ,[Defence] = @Defence
      ,[Agility] = @Agility
      ,[Lucky] = @Lucky
      ,[Attack] = @Attack
      ,[ModelID] = @ModelID
      ,[ResourcesPath] = @ResourcesPath
      ,[DropRate] = @DropRate
      ,[Experience] = @Experience
      ,[Delay] = @Delay
      ,[Immunity] = @Immunity
      ,[Alert] = @Alert
      ,[Range] = @Range
      ,[Preserve] = @Preserve
      ,[Script] = @Script
      ,[FireX] = @FireX
      ,[FireY] = @FireY
      ,[DropId] = @DropId
 WHERE  [ID] = @ID
return 1  
end
--add Game_Map
else 
begin
INSERT INTO [Db_Tank].[dbo].[NPC_Info]
           ([ID]
           ,[Name]
           ,[Level]
           ,[Camp]
           ,[Type]
           ,[X]
           ,[Y]
           ,[Width]
           ,[Height]
           ,[Blood]
           ,[MoveMin]
           ,[MoveMax]
           ,[BaseDamage]
           ,[BaseGuard]
           ,[Defence]
           ,[Agility]
           ,[Lucky]
           ,[Attack]
           ,[ModelID]
           ,[ResourcesPath]
           ,[DropRate]
           ,[Experience]
           ,[Delay]
           ,[Immunity]
           ,[Alert]
           ,[Range]
           ,[Preserve]
           ,[Script]
           ,[FireX]
           ,[FireY]
           ,[DropId])
     VALUES
           (@ID,
           @Name,
           @Level,
           @Camp,
           @Type,
           @X,
           @Y,
           @Width,
           @Height,
           @Blood,
           @MoveMin,
           @MoveMax,
           @BaseDamage,
           @BaseGuard,
           @Defence,
           @Agility,
           @Lucky,
           @Attack,
           @ModelID,
           @ResourcesPath,
           @DropRate,
           @Experience,
           @Delay,
           @Immunity,
           @Alert,
           @Range,
           @Preserve,
           @Script,
           @FireX,
           @FireY,
           @DropId)
           
return 0
           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


