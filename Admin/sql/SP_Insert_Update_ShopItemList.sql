USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_ShopItemList]    Script Date: 06/05/2012 18:59:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_ShopItemList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_ShopItemList]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_ShopItemList]    Script Date: 06/05/2012 18:59:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<公会信息：加入一条用户申请结婚信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Update_ShopItemList]
           @ID float,
           @ShopID float,
           @GroupID float,
           @TemplateID float,
           @BuyType float,
           @IsContinue bit,
           @IsBind float,
           @IsVouch float,
           @Label float,
           @Beat float,
           @AUnit float,
           @APrice1 float,
           @AValue1 float,
           @APrice2 float,
           @AValue2 float,
           @APrice3 float,
           @AValue3 float,
           @BUnit float,
           @BPrice1 float,
           @BValue1 float,
           @BPrice2 float,
           @BValue2 float,
           @BPrice3 float,
           @BValue3 float,
           @CUnit float,
           @CPrice1 float,
           @CValue1 float,
           @CPrice2 float,
           @CValue2 float,
           @CPrice3 float,
           @Sort float,
           @CValue3 float,
           ---IsCheap
           ---LimitCount 
           ---StartDate
           ---EndDate
           @setUpdate int

AS
declare @count int

select @count= isnull(count(*),0) from Shop where ID = @ID
if (@count <> 0 and @setUpdate = 0)
begin
  update [Db_Tank].[dbo].[Shop] 
set    [ID] = @ID
      ,[ShopID] = @ShopID
      ,[GroupID] = @GroupID
      ,[TemplateID] = @TemplateID
      ,[BuyType] = @BuyType
      ,[IsContinue] = @IsContinue
      ,[IsBind] = @IsBind
      ,[IsVouch] = @IsVouch
      ,[Label] = @Label
      ,[Beat] = @Beat
      ,[AUnit] = @AUnit
      ,[APrice1] = @APrice1
      ,[AValue1] = @AValue1
      ,[APrice2] = @APrice2
      ,[AValue2] = @AValue2
      ,[APrice3] = @APrice3
      ,[AValue3] = @AValue3
      ,[BUnit] = @BUnit
      ,[BPrice1] = @BPrice1
      ,[BValue1] = @BValue1
      ,[BPrice2] = @BPrice2
      ,[BValue2] = @BValue2
      ,[BPrice3] = @BPrice3
      ,[BValue3] = @BValue3
      ,[CUnit] = @CUnit
      ,[CPrice1] = @CPrice1
      ,[CValue1] = @CValue1
      ,[CPrice2] = @CPrice2
      ,[CValue2] = @CValue2
      ,[CPrice3] = @CPrice3
      ,[Sort] = @Sort
      ,[CValue3] = @CValue3
      where [ID]  = @ID
      
return 1

end
--add Ball
else 
begin
insert into [Db_Tank].[dbo].[Shop]
           ([ID]
           ,[ShopID]
           ,[GroupID]
           ,[TemplateID]
           ,[BuyType]
           ,[IsContinue]
           ,[IsBind]
           ,[IsVouch]
           ,[Label]
           ,[Beat]
           ,[AUnit]
           ,[APrice1]
           ,[AValue1]
           ,[APrice2]
           ,[AValue2]
           ,[APrice3]
           ,[AValue3]
           ,[BUnit]
           ,[BPrice1]
           ,[BValue1]
           ,[BPrice2]
           ,[BValue2]
           ,[BPrice3]
           ,[BValue3]
           ,[CUnit]
           ,[CPrice1]
           ,[CValue1]
           ,[CPrice2]
           ,[CValue2]
           ,[CPrice3]
           ,[Sort]
           ,[CValue3])
     VALUES
           (@ID,
           @ShopID,
           @GroupID,
           @TemplateID,
           @BuyType,
           @IsContinue,
           @IsBind,
           @IsVouch,
           @Label,
           @Beat,
           @AUnit,
           @APrice1,
           @AValue1,
           @APrice2,
           @AValue2,
           @APrice3,
           @AValue3,
           @BUnit,
           @BPrice1,
           @BValue1,
           @BPrice2,
           @BValue2,
           @BPrice3,
           @BValue3,
           @CUnit,
           @CPrice1,
           @CValue1,
           @CPrice2,
           @CValue2,
           @CPrice3,
           @Sort,
           @CValue3)
           
return 0

           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


