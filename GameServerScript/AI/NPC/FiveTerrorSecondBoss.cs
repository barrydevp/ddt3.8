using Game.Logic;
using Game.Logic.AI;
using Game.Logic.Phy.Object;
using System.Collections.Generic;

namespace GameServerScript.AI.NPC
{
    public class FiveTerrorSecondBoss : ABrain
    {
        private int int_0;

        protected Player m_targer;

        private SimpleBoss simpleBoss_0;

        private SimpleBoss simpleBoss_1;

        private SimpleNpc simpleNpc_0;

        private SimpleNpc simpleNpc_1;

        private List<PhysicalObj> list_0;

        private bool bool_0;

        private int int_1;

        private int int_2;

        private int int_3;

        private int int_4;

        private int int_5;

        public override void OnBeginSelfTurn()
        {
			base.OnBeginSelfTurn();
        }

        public override void OnBeginNewTurn()
        {
			base.OnBeginNewTurn();
			m_body.CurrentDamagePlus = 1f;
			m_body.CurrentShootMinus = 1f;
			if (simpleBoss_0 == null || simpleBoss_1 == null)
			{
				foreach (Living item in base.Game.FindAllTurnBossLiving())
				{
					if (((SimpleBoss)item).NpcInfo.ID == int_1)
					{
						simpleBoss_0 = item as SimpleBoss;
					}
					else if (((SimpleBoss)item).NpcInfo.ID == int_2)
					{
						simpleBoss_1 = item as SimpleBoss;
					}
				}
			}
			if (simpleNpc_0 == null || simpleNpc_1 == null)
			{
				SimpleNpc[] array = base.Game.FindAllNpc();
				SimpleNpc[] array2 = array;
				SimpleNpc[] array3 = array2;
				foreach (SimpleNpc simpleNpc in array3)
				{
					if (simpleNpc.NpcInfo.ID == int_3)
					{
						simpleNpc_0 = simpleNpc;
					}
					else if (simpleNpc.NpcInfo.ID == int_4)
					{
						simpleNpc_1 = simpleNpc;
					}
				}
				simpleNpc_0.Properties1 = 0;
				simpleNpc_1.Properties1 = 0;
			}
			if (list_0.Count <= 0)
			{
				return;
			}
			foreach (PhysicalObj item2 in list_0)
			{
				base.Game.RemovePhysicalObj(item2, sendToClient: true);
			}
			list_0 = new List<PhysicalObj>();
        }

        public override void OnCreated()
        {
			base.OnCreated();
			bool_0 = true;
        }

        public override void OnStartAttacking()
        {
			base.OnStartAttacking();
			bool flag = false;
			foreach (Player allLivingPlayer in base.Game.GetAllLivingPlayers())
			{
				if (allLivingPlayer.X > 1138)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				method_0();
				return;
			}
			int_0++;
			switch (int_0)
			{
			case 1:
				if (simpleBoss_0.IsLiving)
				{
					method_2();
				}
				else
				{
					method_1(null);
				}
				break;
			case 2:
			{
				LivingCallBack livingCallBack = null;
				livingCallBack = ((!bool_0) ? new LivingCallBack(method_3) : new LivingCallBack(method_5));
				if (simpleBoss_1.IsLiving)
				{
					nNawOxxnSwm(livingCallBack);
				}
				else
				{
					method_1(livingCallBack);
				}
				break;
			}
			case 3:
				if (bool_0)
				{
					bool_0 = false;
					method_6();
				}
				else
				{
					bool_0 = true;
					method_4();
				}
				int_0 = 0;
				break;
			}
        }

        private void method_0()
        {
			base.Body.CurrentDamagePlus = 1000f;
			base.Body.PlayMovie("beatA", 1000, 0);
			base.Body.RangeAttacking(1138, 2000, "cry", 4000, directDamage: true);
        }

        private void method_1(LivingCallBack livingCallBack_0)
        {
			base.Body.CurrentDamagePlus = 3f;
			m_targer = base.Game.FindRandomPlayer();
			base.Body.PlayMovie("beatA", 1000, 0);
			base.Body.CallFuction(method_9, 3600);
			base.Body.BeatDirect(m_targer, "", 4000, 1, 1);
			if (livingCallBack_0 != null)
			{
				base.Body.CallFuction(livingCallBack_0, 5000);
			}
        }

        private void method_2()
        {
			simpleBoss_0.CurrentDamagePlus = 2.5f;
			base.Body.PlayMovie("beatD", 1000, 0);
			simpleBoss_0.PlayMovie("failB", 1900, 0);
			simpleBoss_0.PlayMovie("beatA", 3000, 4500);
			((PVEGame)base.Game).SendFreeFocus(618, 585, 1, 5000, 0);
			simpleBoss_0.CallFuction(method_8, 5800);
			simpleBoss_0.RangeAttacking(simpleBoss_0.X - 10000, simpleBoss_0.X + 10000, "cry", 6300, null);
        }

        private void nNawOxxnSwm(LivingCallBack livingCallBack_0)
        {
			m_targer = base.Game.FindRandomPlayer();
			if (m_targer != null)
			{
				base.Body.PlayMovie("beatC", 1000, 0);
				base.Body.CallFuction(method_10, 4000);
				if (simpleBoss_1.ShootPoint(m_targer.X - 15, m_targer.Y - 15, 56, 1000, 10000, 1, 2.5f, 6200))
				{
					simpleBoss_1.PlayMovie("beatA", 3500, 0);
				}
				if (livingCallBack_0 != null)
				{
					base.Body.CallFuction(livingCallBack_0, 10000);
				}
			}
        }

        private void method_3()
        {
			simpleNpc_0.Properties1 = 1;
			((PVEGame)base.Game).SendObjectFocus(simpleNpc_0, 1, 1000, 0);
			simpleNpc_0.PlayMovie("toA", 2000, 3000);
			method_7();
        }

        private void method_4()
        {
			simpleNpc_0.Properties1 = 0;
			simpleNpc_0.CurrentDamagePlus = 5.5f;
			((PVEGame)base.Game).SendObjectFocus(base.Body, 1, 1000, 0);
			base.Body.PlayMovie("beatC", 2000, 0);
			((PVEGame)base.Game).SendObjectFocus(simpleNpc_0, 1, 5000, 0);
			simpleNpc_0.PlayMovie("beatA", 6000, 5000);
			foreach (Player allLivingPlayer in base.Game.GetAllLivingPlayers())
			{
				if (allLivingPlayer.Y > 760)
				{
					simpleNpc_0.BeatDirect(allLivingPlayer, "", 8000, 1, 1);
				}
			}
			method_7();
        }

        private void method_5()
        {
			simpleNpc_1.Properties1 = 1;
			simpleNpc_1.CurrentDamagePlus = 2f;
			((PVEGame)base.Game).SendObjectFocus(simpleNpc_1, 1, 1000, 0);
			simpleNpc_1.PlayMovie("toA", 2000, 3000);
        }

        private void method_6()
        {
			simpleNpc_1.Properties1 = 0;
			((PVEGame)base.Game).SendObjectFocus(base.Body, 1, 1000, 0);
			base.Body.PlayMovie("beatB", 2000, 0);
			simpleNpc_1.PlayMovie("beatA", 5000, 6000);
			foreach (Player allLivingPlayer in base.Game.GetAllLivingPlayers())
			{
				if ((allLivingPlayer.X <= 166 && allLivingPlayer.Y <= 760) || (allLivingPlayer.X >= 342 && allLivingPlayer.X <= 637 && allLivingPlayer.Y <= 760) || (allLivingPlayer.X >= 820 && allLivingPlayer.X <= 1116 && allLivingPlayer.Y <= 760) || (allLivingPlayer.X > 166 && allLivingPlayer.X < 342 && allLivingPlayer.Y > 760) || (allLivingPlayer.X > 637 && allLivingPlayer.X < 820 && allLivingPlayer.Y > 760))
				{
					simpleNpc_1.BeatDirect(allLivingPlayer, "", 11000, 3, 1);
				}
			}
        }

        private void method_7()
        {
			if (simpleNpc_0.Properties1 == 1)
			{
				((PVEGame)base.Game).SendLivingActionMapping(simpleNpc_0, "stand", "standA");
			}
			else
			{
				((PVEGame)base.Game).SendLivingActionMapping(simpleNpc_0, "stand", "stand");
			}
        }

        private void method_8()
        {
			foreach (Player allLivingPlayer in base.Game.GetAllLivingPlayers())
			{
				list_0.Add(((PVEGame)base.Game).Createlayer(allLivingPlayer.X, allLivingPlayer.Y, "", "asset.game.4.xiaopao", "", 1, 1));
			}
        }

        private void method_9()
        {
			if (m_targer != null)
			{
				list_0.Add(((PVEGame)base.Game).Createlayer(m_targer.X, m_targer.Y, "", "asset.game.4.jinqudan", "", 1, 1));
			}
        }

        private void method_10()
        {
			base.Body.AddBlood(int_5);
			simpleBoss_0.AddBlood(int_5);
			simpleBoss_1.AddBlood(int_5);
        }

        public override void OnStopAttacking()
        {
			base.OnStopAttacking();
        }

        public FiveTerrorSecondBoss()
        {
			list_0 = new List<PhysicalObj>();
			bool_0 = true;
			int_1 = 5312;
			int_2 = 5313;
			int_3 = 5316;
			int_4 = 5317;
			int_5 = 20000;
        }
    }
}
