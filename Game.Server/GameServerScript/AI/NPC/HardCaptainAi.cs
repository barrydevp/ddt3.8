using Game.Logic.AI;
using Game.Logic.Phy.Object;
using System.Collections.Generic;
using System.Drawing;

namespace GameServerScript.AI.NPC
{
    public class HardCaptainAi : ABrain
    {
        private int int_0;

        private int int_1;

        private int int_2;

        private List<SimpleNpc> list_0;

        private int int_3;

        private static string[] string_0;

        private static string[] string_1;

        private static string[] string_2;

        private static string[] string_3;

        private static string[] string_4;

        private static string[] string_5;

        private static string[] string_6;

        private Point[] brithPoint = new Point[2]
		{
			new Point(600, 539),
			new Point(950, 539)
		};

        public override void OnBeginSelfTurn()
        {
			base.OnBeginSelfTurn();
        }

        public override void OnBeginNewTurn()
        {
			base.OnBeginNewTurn();
			base.Body.CurrentDamagePlus = 1f;
			base.Body.CurrentShootMinus = 1f;
			base.Body.SetRect(((SimpleBoss)base.Body).NpcInfo.X, ((SimpleBoss)base.Body).NpcInfo.Y, ((SimpleBoss)base.Body).NpcInfo.Width, ((SimpleBoss)base.Body).NpcInfo.Height);
			if (base.Body.Direction == -1)
			{
				base.Body.SetRect(((SimpleBoss)base.Body).NpcInfo.X, ((SimpleBoss)base.Body).NpcInfo.Y, ((SimpleBoss)base.Body).NpcInfo.Width, ((SimpleBoss)base.Body).NpcInfo.Height);
			}
			else
			{
				base.Body.SetRect(-((SimpleBoss)base.Body).NpcInfo.X - ((SimpleBoss)base.Body).NpcInfo.Width, ((SimpleBoss)base.Body).NpcInfo.Y, ((SimpleBoss)base.Body).NpcInfo.Width, ((SimpleBoss)base.Body).NpcInfo.Height);
			}
        }

        public override void OnCreated()
        {
			base.OnCreated();
        }

        public override void OnStartAttacking()
        {
			base.Body.Direction = base.Game.FindlivingbyDir(base.Body);
			bool flag = false;
			int num = 0;
			foreach (Player allFightPlayer in base.Game.GetAllFightPlayers())
			{
				if (allFightPlayer.IsLiving && allFightPlayer.X > 500 && allFightPlayer.X < 1050)
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
				method_0(500, 1050);
			}
			else if (int_0 == 0)
			{
				method_1();
				int_0++;
			}
			else if (int_0 == 1)
			{
				method_2();
				int_0++;
			}
			else
			{
				method_3();
				int_0 = 0;
			}
        }

        public override void OnStopAttacking()
        {
			base.OnStopAttacking();
        }

        private void method_0(int int_4, int int_5)
        {
			method_5(3);
			int num = base.Game.Random.Next(0, string_6.Length);
			base.Body.Say(string_6[num], 1, 1000);
			base.Body.CurrentDamagePlus = 100f;
			base.Body.PlayMovie("beat2", 3000, 0);
			base.Body.RangeAttacking(int_4, int_5, "cry", 5000, null);
        }

        private void method_1()
        {
			method_5(3);
			base.Body.CurrentDamagePlus = 2f;
			int num = base.Game.Random.Next(0, string_0.Length);
			base.Body.Say(string_0[num], 1, 0);
			base.Body.FallFrom(base.Body.X, 509, null, 1000, 1, 12);
			base.Body.PlayMovie("beat2", 1000, 0);
			base.Body.RangeAttacking(base.Body.X - 1000, base.Body.X + 1000, "cry", 4000, null);
        }

        private void method_2()
        {
			method_5(3);
			int num = base.Game.Random.Next(0, string_1.Length);
			base.Body.Say(string_1[num], 1, 0);
			int x = base.Game.Random.Next(670, 880);
			int direction = base.Body.Direction;
			base.Body.MoveTo(x, base.Body.Y, "walk", 1000, "", 4, method_4);
			base.Body.ChangeDirection(base.Game.FindlivingbyDir(base.Body), 9000);
        }

        private void method_3()
        {
			method_5(3);
			base.Body.JumpTo(base.Body.X, base.Body.Y - 300, "Jump", 1000, 1);
			int num = base.Game.Random.Next(0, string_3.Length);
			base.Body.Say(string_3[num], 1, 3300);
			base.Body.PlayMovie("call", 3500, 0);
			base.Body.CallFuction(CreateChild, 4000);
        }

        private void method_4()
        {
			Player player = base.Game.FindRandomPlayer();
			base.Body.SetRect(0, 0, 0, 0);
			if (player.X > base.Body.Y)
			{
				base.Body.ChangeDirection(1, 500);
			}
			else
			{
				base.Body.ChangeDirection(-1, 500);
			}
			base.Body.CurrentDamagePlus = 1f;
			if (player != null)
			{
				int x = base.Game.Random.Next(player.X - 50, player.X + 50);
				if (base.Body.ShootPoint(x, player.Y, 61, 1000, 10000, 1, 1f, 2200))
				{
					base.Body.PlayMovie("beat", 1700, 0);
				}
				if (base.Body.ShootPoint(x, player.Y, 61, 1000, 10000, 1, 1f, 3200))
				{
					base.Body.PlayMovie("beat", 2700, 0);
				}
			}
        }

        private void method_5(int int_4)
        {
			int direction = base.Body.Direction;
			for (int i = 0; i < int_4; i++)
			{
				base.Body.ChangeDirection(-direction, i * 200 + 100);
				base.Body.ChangeDirection(direction, (i + 1) * 100 + i * 200);
			}
        }

        public void CreateChild()
        {
			((SimpleBoss)base.Body).CreateChild(int_3, brithPoint, 8, 2, 1);
        }

        public HardCaptainAi()
        {
			list_0 = new List<SimpleNpc>();
			int_3 = 1209;
        }

        static HardCaptainAi()
        {
			string_0 = new string[3]
			{
				"?????i ?????a <br/> ch???n .... <br/> ch???n ......",
				"C??c ng????i ??ang t??? t??m t???i c??i ch???t ?????y!",
				"Si??u ?????ng ?????t b???t kh??? chi???n b???i <br/> ...... GRR ... GRR ......"
			};
			string_1 = new string[2]
			{
				"Coi anh b???n n??.",
				"V??? m???t n??y!"
			};
			string_2 = new string[3]
			{
				"Xu???ng ??i ng???c ??i c??ng!",
				"Ng????i ngh?? c?? th??? ????nh b???i ta?",
				"Luy???n th??m ??i tr?????c khi ????i ????nh b???i ta"
			};
			string_3 = new string[2]
			{
				"V??? binh! <br/> b???o v???! ! ",
				"C??c em, G??! <br/> gi??p t??i!"
			};
			string_4 = new string[3]
			{
				"??i ?????ch ...",
				"D??m b???n ta ?? GRRR ...",
				"R??t qu??, ta kh??ng tha th???!!!"
			};
			string_5 = new string[3]
			{
				"B???n ta ??? Th??? ??i, <br/> b???n v??o ta ??i!",
				"L??n cao n??o! Nh???y cao n??o!",
				"Cao! <br/> l??n cao n??o!"
			};
			string_6 = new string[4]
			{
				"Ng????i ngh?? l???i g???n ta m?? s???ng s??t ???",
				"M???t th???ng ngu lao v??o ch??? ch???t",
				"T???i g???n ta l??m g?? h????",
				"Tr??? ranh ch??a t???i tu???i ch???m v??o m??ng ta!!!"
			};
        }
    }
}
