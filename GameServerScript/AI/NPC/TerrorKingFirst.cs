using Game.Logic.AI;
using Game.Logic.Phy.Object;

namespace GameServerScript.AI.NPC
{
    public class TerrorKingFirst : ABrain
    {
        private int int_0;

        private static string[] string_0;

        private static string[] string_1;

        private static string[] string_2;

        private static string[] guLwScGpYy6;

        private static string[] string_3;

        public override void OnBeginSelfTurn()
        {
			base.OnBeginSelfTurn();
        }

        public override void OnBeginNewTurn()
        {
			base.OnBeginNewTurn();
			m_body.CurrentDamagePlus = 1f;
			m_body.CurrentShootMinus = 1f;
        }

        public override void OnCreated()
        {
			base.OnCreated();
        }

        public override void OnStartAttacking()
        {
			base.OnStartAttacking();
			base.Body.Direction = base.Game.FindlivingbyDir(base.Body);
			bool flag = false;
			int num = 0;
			foreach (Player allFightPlayer in base.Game.GetAllFightPlayers())
			{
				if (allFightPlayer.IsLiving && allFightPlayer.X > 620 && allFightPlayer.X < 1160)
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
				method_0(620, 1160);
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

        private void method_0(int int_1, int int_2)
        {
			base.Body.CurrentDamagePlus = 100f;
			int num = base.Game.Random.Next(0, string_3.Length);
			base.Body.Say(string_3[num], 1, 1000);
			base.Body.PlayMovie("beat", 3000, 0);
			base.Body.RangeAttacking(int_1, int_2, "cry", 4000, null);
        }

        private void method_1()
        {
			base.Body.CurrentDamagePlus = 1.5f;
			int num = base.Game.Random.Next(0, string_0.Length);
			base.Body.Say(string_0[num], 1, 0);
			base.Body.PlayMovie("beat", 1000, 0);
			base.Body.RangeAttacking(base.Body.X - 1000, base.Body.X + 1000, "cry", 3000, null);
        }

        private void method_2()
        {
			int x = base.Game.Random.Next(798, 980);
			base.Body.MoveTo(x, base.Body.Y, "walk", 1000, "", 4, method_4);
        }

        private void method_3()
        {
			int num = base.Game.Random.Next(0, guLwScGpYy6.Length);
			base.Body.Say(guLwScGpYy6[num], 1, 0);
			base.Body.SyncAtTime = true;
			base.Body.AddBlood(5000);
			base.Body.PlayMovie("", 1000, 4500);
        }

        private void method_4()
        {
			Player player = base.Game.FindRandomPlayer();
			if (player.X > base.Body.Y)
			{
				base.Body.ChangeDirection(1, 800);
			}
			else
			{
				base.Body.ChangeDirection(-1, 800);
			}
			base.Body.CurrentDamagePlus = 1.8f;
			int num = base.Game.Random.Next(0, string_1.Length);
			base.Body.Say(string_1[num], 1, 0);
			if (player != null)
			{
				if (base.Body.ShootPoint(player.X, player.Y, 61, 1000, 10000, 1, 3f, 2300))
				{
					base.Body.PlayMovie("beat2", 1500, 0);
				}
				if (base.Body.ShootPoint(player.X, player.Y, 61, 1000, 10000, 1, 3f, 4100))
				{
					base.Body.PlayMovie("beat2", 3300, 0);
				}
				if (base.Body.ShootPoint(player.X, player.Y, 61, 1000, 10000, 1, 3f, 5900))
				{
					base.Body.PlayMovie("beat2", 5100, 0);
				}
			}
        }

        public override void OnStopAttacking()
        {
			base.OnStopAttacking();
        }

        static TerrorKingFirst()
        {
			string_0 = new string[3]
			{
				"Coi bạn đỡ được bao lâu!",
				"Hạ vũ khí xuống!",
				"Xem nếu bạn có thể đủ khả năng, một số ít!！"
			};
			string_1 = new string[3]
			{
				"Bách phát bách trúng!",
				"Gửi cho bạn một quả bóng - bạn phải chọn Vâng",
				"Đám người này chưa biết sợ!!"
			};
			string_2 = new string[2]
			{
				"Ah ~ ~ Tại sao bạn tấn công? <br/> tôi đang làm gì?",
				"Oh ~ ~ nó thực sự đau khổ! Tại sao tôi phải chiến đấu? <br/> tôi phải chiến đấu ..."
			};
			guLwScGpYy6 = new string[3]
			{
				"Xoắn ah xoay ~ <br/>xoắn ah xoay ~ ~ ~",
				"~ Hallelujah <br/>Luyaluya ~ ~ ~",
				"Yeah Yeah Yeah, <br/> để thoải mái!"
			};
			string_3 = new string[1]
			{
				"Thánh thượng tới! !"
			};
        }
    }
}
