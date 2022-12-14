USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_Shop_Goods_Box]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_Shop_Goods_Box]
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
CREATE PROCEDURE [dbo].[SP_Insert_Update_Shop_Goods_Box] 
		   @Id int,
           @DataId int,
           @TemplateId int,
           @IsSelect bit,
           @IsBind bit,
           @ItemValid int,
           @ItemCount int,
           @StrengthenLevel int,
           @AttackCompose int,
           @DefendCompose int,
           @AgilityCompose int,
           @LuckCompose int,
           @Random int,
           @IsTips bit,
           @IsLogs bit,
           @setUpdate int
AS

declare @count int

select @count= isnull(count(*),0) from [Shop_Goods_Box] where ID = @ID
if (@count <> 0 and @setUpdate = 0)
begin
UPDATE [Db_Tank].[dbo].[Shop_Goods_Box]
   SET [Id] = @Id
      ,[DataId] = @DataId
      ,[TemplateId] = @TemplateId
      ,[IsSelect] = @IsSelect
      ,[IsBind] = @IsBind
      ,[ItemValid] = @ItemValid
      ,[ItemCount] = @ItemCount
      ,[StrengthenLevel] = @StrengthenLevel
      ,[AttackCompose] = @AttackCompose
      ,[DefendCompose] = @DefendCompose
      ,[AgilityCompose] = @AgilityCompose
      ,[LuckCompose] = @LuckCompose
      --,[Random] = @Random
      ,[IsTips] = @IsTips
      ,[IsLogs] = @IsLogs
 WHERE [Id] = @Id
    
return 1  
end
--add Shop_Goods_Box
else 
begin
INSERT INTO [Db_Tank].[dbo].[Shop_Goods_Box]
           ([Id]
           ,[DataId]
           ,[TemplateId]
           ,[IsSelect]
           ,[IsBind]
           ,[ItemValid]
           ,[ItemCount]
           ,[StrengthenLevel]
           ,[AttackCompose]
           ,[DefendCompose]
           ,[AgilityCompose]
           ,[LuckCompose]
           ,[Random]
           ,[IsTips]
           ,[IsLogs])
     VALUES
           (@Id,
           @DataId,
           @TemplateId,
           @IsSelect,
           @IsBind,
           @ItemValid,
           @ItemCount,
           @StrengthenLevel,
           @AttackCompose,
           @DefendCompose,
           @AgilityCompose,
           @LuckCompose,
           @Random,
           @IsTips,
           @IsLogs)
           
return 0
           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


