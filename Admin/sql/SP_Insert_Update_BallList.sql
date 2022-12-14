USE [Db_Tank]
GO

/****** Object:  StoredProcedure [dbo].[SP_Insert_BallList]    Script Date: 06/05/2012 19:00:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Insert_Update_BallList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Insert_Update_BallList]
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
CREATE PROCEDURE [dbo].[SP_Insert_Update_BallList] 
		   @ID int,
           @Name nvarchar(200),
           @Power float,
           @Radii int,
           @FlyingPartical nvarchar(200),
           @BombPartical nvarchar(200),
           @Crater nvarchar(200),
           @AttackResponse int,
           @IsSpin bit,
           @Mass int,
           @SpinVA float,
           @SpinV int,
           @Amount int,
           @Wind int,
           @DragIndex int,
           @Weight int,
           @Shake bit,
           @ShootSound nvarchar(50),
           @BombSound nvarchar(50),
           @Delay int,
           @ActionType int,
           @HasTunnel bit,
           @setUpdate int
AS

declare @count int

select @count= isnull(count(*),0) from Ball where ID = @ID
if (@count <> 0 and @setUpdate = 0)
begin
  update [Db_Tank].[dbo].[Ball]
  set 
	   [ID] = @ID
      ,[Name] = @Name
      ,[Power] = @Power
      ,[Radii] = @Radii
      ,[FlyingPartical] = @FlyingPartical
      ,[BombPartical] = @BombPartical
      ,[Crater] = @Crater
      ,[AttackResponse] = @AttackResponse
      ,[IsSpin] = @IsSpin
      ,[Mass] = @Mass
      ,[SpinVA] = @SpinVA
      ,[SpinV] = @SpinV
      ,[Amount] = @Amount
      ,[Wind] = @Wind
      ,[DragIndex] = @DragIndex
      ,[Weight] = @Weight
      ,[Shake] = @Shake
      ,[ShootSound] = @ShootSound
      ,[BombSound] = @BombSound
      ,[Delay] = @Delay
      ,[ActionType] = @ActionType
      ,[HasTunnel] = @HasTunnel
      where [ID]  = @ID
    
return 1  
end
--add Ball
else 
begin
insert into [Db_Tank].[dbo].[Ball]
           ([ID]
           ,[Name]
           ,[Power]
           ,[Radii]
           ,[FlyingPartical]
           ,[BombPartical]
           ,[Crater]
           ,[AttackResponse]
           ,[IsSpin]
           ,[Mass]
           ,[SpinVA]
           ,[SpinV]
           ,[Amount]
           ,[Wind]
           ,[DragIndex]
           ,[Weight]
           ,[Shake]
           ,[ShootSound]
           ,[BombSound]
           ,[Delay]
           ,[ActionType]
           ,[HasTunnel])
     VALUES
           (@ID,
           @Name,
           @Power,
           @Radii,
           @FlyingPartical,
           @BombPartical,
           @Crater,
           @AttackResponse,
           @IsSpin,
           @Mass,
           @SpinVA,
           @SpinV,
           @Amount,
           @Wind,
           @DragIndex,
           @Weight,
           @Shake,
           @ShootSound,
           @BombSound,
           @Delay,
           @ActionType,
           @HasTunnel)
           
return 0
           end
if(@@error <> 0)
begin
  return 2 ---Return false insert error
end

GO


