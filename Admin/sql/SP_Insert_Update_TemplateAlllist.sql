USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_TemplateAlllist]    Script Date: 06/05/2012 19:00:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_TemplateAlllist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_TemplateAlllist]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_TemplateAlllist]    Script Date: 06/05/2012 19:00:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<公会信息：加入一条用户申请结婚信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Update_TemplateAlllist] 
		   @TemplateID int,
           @Name nvarchar(50),
           --@Remark nvarchar(200),
           @CategoryID int,
           @Description nvarchar(200),
           @Attack int,
           @Defence int,
           @Agility int,
           @Luck int,
           @Level int,
           @Quality int,
           @Pic nvarchar(200),
           @MaxCount int,
           @NeedSex int,
           @NeedLevel int,
           @CanStrengthen bit,
           @CanCompose bit,
           @CanDrop bit,
           @CanEquip bit,
           @CanUse bit,
           @CanDelete bit,
           @Script nvarchar(200),
           @Data nvarchar(1000),
           @Colors nvarchar(1000),
           @Property1 int,
           @Property2 int,
           @Property3 int,
           @Property4 int,
           @Property5 int,
           @Property6 int,
           @Property7 int,
           @Property8 int,
           --@Valid int,
           --@Count int,
           @AddTime datetime,
           @BindType int,
           --@FusionType int,
           --@FusionRate int,
           --@FusionNeedRate int,
           @Hole nvarchar(50),
           @RefineryLevel int,
           --@ReclaimValue int,
		   --@ReclaimType int,
		   --@CanRecycle bit
		   @setUpdate int

AS

declare @countItems int

select @countItems= isnull(count(*),0) from Shop_Goods where TemplateID  = @TemplateID
if (@countItems <> 0 and @setUpdate = 0)
begin
 update [Db_Tank].[dbo].[Shop_Goods] 
set 
	   [TemplateID] =@TemplateID
      ,[Name] =@Name
      ,[Remark] =''
      ,[CategoryID] =@CategoryID
      ,[Description] =@Description
      ,[Attack] =@Attack
      ,[Defence] =@Defence
      ,[Agility] =@Agility
      ,[Luck] =@Luck
      ,[Level] =@Level
      ,[Quality] =@Quality
      ,[Pic] =@Pic
      ,[MaxCount] =@MaxCount
      ,[NeedSex] =@NeedSex
      ,[NeedLevel] =@NeedLevel
      ,[CanStrengthen] =@CanStrengthen
      ,[CanCompose] =@CanCompose
      ,[CanDrop] =@CanDrop
      ,[CanEquip] =@CanEquip
      ,[CanUse] =@CanUse
      ,[CanDelete] =@CanDelete
      ,[Script] =@Script
      ,[Data] =@Data
      ,[Colors] =@Colors
      ,[Property1] =@Property1
      ,[Property2] =@Property2
      ,[Property3] =@Property3
      ,[Property4] =@Property4
      ,[Property5] =@Property5
      ,[Property6] =@Property6
      ,[Property7] =@Property7
      ,[Property8] =@Property8
      ,[Valid] =0
      ,[Count] =0
      ,[AddTime] =@AddTime
      ,[BindType] =@BindType
      ,[FusionType] =0
      ,[FusionRate] =0
      ,[FusionNeedRate] =0
      ,[Hole] =@Hole
      ,[RefineryLevel] =@RefineryLevel
		   --,[ReclaimValue] =@ReclaimValue
		   --,[ReclaimType] =@ReclaimType
		   --,[CanRecycle] =@CanRecycle
      where TemplateID  = @TemplateID  --and LoveProclamation = @LoveProclamation 
      
return 1
end
--add Ball
else 
begin
insert into [Db_Tank].[dbo].[Shop_Goods]
           ([TemplateID]
           ,[Name]
           ,[Remark]
           ,[CategoryID]
           ,[Description]
           ,[Attack]
           ,[Defence]
           ,[Agility]
           ,[Luck]
           ,[Level]
           ,[Quality]
           ,[Pic]
           ,[MaxCount]
           ,[NeedSex]
           ,[NeedLevel]
           ,[CanStrengthen]
           ,[CanCompose]
           ,[CanDrop]
           ,[CanEquip]
           ,[CanUse]
           ,[CanDelete]
           ,[Script]
           ,[Data]
           ,[Colors]
           ,[Property1]
           ,[Property2]
           ,[Property3]
           ,[Property4]
           ,[Property5]
           ,[Property6]
           ,[Property7]
           ,[Property8]
           ,[Valid]
           ,[Count]
           ,[AddTime]
           ,[BindType]
           ,[FusionType]
           ,[FusionRate]
           ,[FusionNeedRate]
           ,[Hole]
           ,[RefineryLevel])
     VALUES
           (@TemplateID,
           @Name,
           '',
           @CategoryID,
           @Description,
           @Attack,
           @Defence,
           @Agility,
           @Luck,
           @Level,
           @Quality,
           @Pic,
           @MaxCount,
           @NeedSex,
           @NeedLevel,
           @CanStrengthen,
           @CanCompose,
           @CanDrop,
           @CanEquip,
           @CanUse,
           @CanDelete,
           @Script,
           @Data,
           @Colors,
           @Property1,
           @Property2,
           @Property3,
           @Property4,
           @Property5,
           @Property6,
           @Property7,
           @Property8,
           0,
           0,
           @AddTime,
           @BindType,
           0,
           0,
           0,
           @Hole,
           @RefineryLevel)
           --@ReclaimValue int,
		   --@ReclaimType int,
		   --@CanRecycle bit)
		   
return 0
		   end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end
GO


