using Game.Logic.AI;
using Game.Logic.Phy.Object;
using System.Collections.Generic;

namespace GameServerScript.AI.NPC
{
    public class ThirdNormalKingThird : ABrain
    {
        private int int_0;

        private int int_1;

        private int int_2;

        private int int_3;

        private int int_4;

        private int int_5;

        public List<SimpleNpc> orchins;

        private static string[] string_0;

        private static string[] string_1;

        private static string[] string_2;

        private static string[] string_3;

        private static string[] string_4;

        private static string[] string_5;

        private static string[] string_6;

        public override void OnBeginSelfTurn()
        {
			base.OnBeginSelfTurn();
			if (int_5 > 0)
			{
				int_5--;
			}
        }

        public override void OnBeginNewTurn()
        {
			base.OnBeginNewTurn();
			base.Body.CurrentDamagePlus = 1f;
			base.Body.CurrentShootMinus = 1f;
        }

        public override void OnCreated()
        {
			base.OnCreated();
        }

        public override void OnStartAttacking()
        {
			bool flag = false;
			int num = 0;
			base.Body.Direction = base.Game.FindlivingbyDir(base.Body);
			foreach (Player allFightPlayer in base.Game.GetAllFightPlayers())
			{
				if (allFightPlayer.IsLiving && allFightPlayer.X > base.Body.X - 250 && allFightPlayer.X < base.Body.X + 250)
				{
					int num2 = (int)base.Body.Distance(allFightPlayer.X, allFightPlayer.Y);
					if (num2 > num)
					{
						num = num2;
					}
					flag = true;
				}
			}
			if (flag)
			{
				KillAttack(base.Body.X - 250, base.Body.X + 250);
				return;
			}
			if (int_0 == 1)
			{
				HalfAttack();
			}
			else if (int_0 == 2)
			{
				method_1();
			}
			else if (int_0 == 3)
			{
				List<SimpleNpc> list = (base.Body as SimpleBoss).FindChildLiving(int_3);
				if (list.Count <= 0)
				{
					Summon();
				}
				else
				{
					(base.Body as SimpleBoss).FindChildLiving(int_2);
					if (list.Count <= 0)
					{
						SummonExplode();
					}
					else
					{
						method_1();
					}
				}
			}
			else if (int_0 == 4)
			{
				method_0();
			}
			else if (int_0 == 5)
			{
				if (base.Game.Random.Next(0, 10) > 5)
				{
					SummonExplode();
				}
				else
				{
					method_1();
				}
			}
			else
			{
				if ((base.Body as SimpleBoss).FindChildLiving(int_1).Count <= 0)
				{
					SummonNpc();
				}
				else
				{
					method_0();
				}
				int_0 = 0;
			}
			int_0++;
        }

        public override void OnStopAttacking()
        {
			base.OnStopAttacking();
			base.Game.RemoveLiving(int_1);
        }

        public void HalfAttack()
        {
			base.Body.CurrentDamagePlus = 1.5f;
			int num = base.Game.Random.Next(0, string_0.Length);
			base.Body.Say(string_0[num], 1, 500);
			base.Body.PlayMovie("beatC", 2500, 0);
			base.Body.RangeAttacking(base.Body.X - 10000, base.Body.Y + 10000, "cry", 3500, null);
        }

        private void method_0()
        {
			Player[] allPlayers = base.Game.GetAllPlayers();
			int num = 200;
			int num2 = base.Game.Random.Next(0, string_1.Length);
			base.Body.Say(string_1[num2], 1, 200);
			Player[] array = allPlayers;
			Player[] array2 = array;
			Player[] array3 = array2;
			foreach (Player player in array3)
			{
				if (player.IsLiving)
				{
					num += 200;
					base.Body.ChangeDirection(base.Body.FindDirection(player), num);
					num += 2000;
					if (base.Body.ShootPoint(player.X, player.Y, 55, 1000, 10000, 1, 1.5f, num))
					{
						base.Body.PlayMovie("beatB", num - 1000, 0);
					}
				}
			}
        }

        private void method_1()
        {
			int x = base.Game.Random.Next(700, 800);
			base.Body.MoveTo(x, base.Body.Y, "walk", 1000, "", 4, method_2);
        }

        private void method_2()
        {
			Player[] allPlayers = base.Game.GetAllPlayers();
			int num = 200;
			int num2 = base.Game.Random.Next(0, string_1.Length);
			base.Body.Say(string_1[num2], 1, 200);
			Player[] array = allPlayers;
			Player[] array2 = array;
			Player[] array3 = array2;
			foreach (Player player in array3)
			{
				if (player.IsLiving)
				{
					num += 200;
					base.Body.ChangeDirection(base.Body.FindDirection(player), num);
					num += 2000;
					if (base.Body.ShootPoint(player.X, player.Y, 54, 1000, 10000, 1, 1.5f, num))
					{
						base.Body.PlayMovie("beatA", num - 1000, 0);
					}
				}
			}
        }

        public void Summon()
        {
			int_5 = 5;
			int num = base.Game.Random.Next(0, string_3.Length);
			base.Body.Say(string_3[num], 1, 0);
			base.Body.PlayMovie("callA", 100, 0);
			base.Body.CallFuction(CreateBuffBlood, 2500);
        }

        public void SummonNpc()
        {
			int num = base.Game.Random.Next(0, string_2.Length);
			base.Body.Say(string_2[num], 1, 0);
			base.Body.PlayMovie("callB", 100, 0);
			base.Body.CallFuction(CreateChild, 4500);
        }

        public void SummonExplode()
        {
			int num = base.Game.Random.Next(0, string_4.Length);
			base.Body.Say(string_4[num], 1, 0);
			base.Body.PlayMovie("callA", 100, 0);
			base.Body.CallFuction(CreateExplode, 2500);
        }

        public void KillAttack(int fx, int mx)
        {
			base.Body.CurrentDamagePlus = 1000f;
			int num = base.Game.Random.Next(0, string_6.Length);
			((SimpleBoss)base.Body).Say(string_6[num], 1, 500);
			base.Body.PlayMovie("beatC", 2500, 0);
			base.Body.RangeAttacking(fx, mx, "cry", 3300, null);
        }

        public void CreateChild()
        {
			int num = 1000;
			for (int i = 0; i < int_4; i++)
			{
				((SimpleBoss)base.Body).CreateChild(int_1, num, 555, -1, int_4, -1);
				num -= 50;
			}
        }

        public void CreateBuffBlood()
        {
			((SimpleBoss)base.Body).CreateBoss(int_3, 568, 554, -1, 0);
			((SimpleBoss)base.Body).CreateBoss(int_3, 1093, 556, 1, 0);
        }

        public void CreateExplode()
        {
			Player player = base.Game.FindRandomPlayer();
			if (player != null)
			{
				((SimpleBoss)base.Body).CreateBoss(int_2, player.X, player.Y, player.Direction, 0);
			}
        }

        public ThirdNormalKingThird()
        {
			int_0 = 1;
			int_1 = 3103;
			int_2 = 3112;
			int_3 = 3113;
			int_4 = 10;
			orchins = new List<SimpleNpc>();
        }

        static ThirdNormalKingThird()
        {
			string_0 = new string[1]
			{
				"Ti???ng g???m c???a m???nh h??? !!..."
			};
			string_1 = new string[4]
			{
				"Nh??n c?? gi???ng c??i g?? kh??ng?",
				"Ta n??m!! T?? n??m!!!!",
				"Gi???i th?? n?? n???a ??i.",
				"B??ch ph??t b??ch tr??ng"
			};
			string_2 = new string[1]
			{
				"V?? ??i???u<br/>s??n b???n...."
			};
			string_3 = new string[3]
			{
				"S???c m???nh b??? t???c<br/>H??y gi??p ta!!!",
				"Ta mu???n c?? nhi???u s???c m???nh!!!!",
				"Ti???p s???c cho ta ti??u di???t k??? th??..."
			};
			string_4 = new string[3]
			{
				"C?? ????? ???????c kh??ng?",
				"B??? l???c h??y gi??p ta",
				"Ti???p s???c!!! Ti???p s???c!!!!"
			};
			string_5 = new string[3]
			{
				"D??m ch???c gi???n ta ???",
				"Ta n??, ta n??!!!",
				"????? kh???n n???n. D??m ????nh ta!!"
			};
			string_6 = new string[1]
			{
				"Mu???n xem l???i h???i c???a c??? h???ng c???a ta!"
			};
        }
    }
}
