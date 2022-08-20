using Game.Logic.AI;

namespace GameServerScript.AI.NPC
{
    public class ThirdHardBloodNpc : ABrain
    {
        private int int_0;

        public override void OnBeginSelfTurn()
        {
			base.OnBeginSelfTurn();
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
			base.OnStartAttacking();
			AddBlood();
        }

        public override void OnStopAttacking()
        {
			base.OnStopAttacking();
        }

        public void AddBlood()
        {
			foreach (Living item in base.Game.FindAllTurnBossLiving())
			{
				if (item.IsLiving)
				{
					item.AddBlood(int_0);
				}
			}
        }

        public ThirdHardBloodNpc()
        {
			int_0 = 2000;
        }
    }
}
