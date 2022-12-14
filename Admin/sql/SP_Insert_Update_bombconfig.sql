USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_bombconfig]    Script Date: 06/05/2012 19:00:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_bombconfig]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_bombconfig]
GO

USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_bombconfig]    Script Date: 06/05/2012 19:00:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Ken>
-- ALTER  date: <2009-10-22>
-- Description:	<公会信息：加入一条用户申请结婚信息>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Insert_Update_bombconfig] 
		   @TemplateID int,
           @Common int,
           @CommonAddWound int,
           @CommonMultiBall int,
           @Special int,
           @SpecialII int,
           @setUpdate int
AS
declare @count int

select @count= isnull(count(*),0) from BallConfig where TemplateID  = @TemplateID 
if (@count <> 0 and @setUpdate = 0)
begin
 update [Db_Tank].[dbo].[BallConfig]
set 
	   [TemplateID] = @TemplateID
      ,[Common] = @Common
      ,[CommonAddWound] = @CommonAddWound
      ,[CommonMultiBall] = @CommonMultiBall
      ,[Special] = @Special
      ,[SpecialII] = @SpecialII
      where TemplateID  = @TemplateID 
      return 1
end
--add Ball
else 
begin
insert into [Db_Tank].[dbo].[BallConfig]
           ([TemplateID]
           ,[Common]
           ,[CommonAddWound]
           ,[CommonMultiBall]
           ,[Special]
           ,[SpecialII])
     VALUES
           (@TemplateID,
           @Common,
           @CommonAddWound,
           @CommonMultiBall,
           @Special,
           @SpecialII)
     return 0      
 end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


