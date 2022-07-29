using Game.Logic.AI;

namespace GameServerScript.AI.Game
{
    public class DragonWarNormalGame : APVEGameControl
    {
        public override void OnCreated()
        {
			base.Game.SetupMissions("5101,5102,5103,5104");
			base.Game.TotalMissionCount = 4;
        }

        public override void OnPrepated()
        {
			//base.Game.SessionId = 0;
        }

        public override int CalculateScoreGrade(int score)
        {
			if (score > 800)
			{
				return 3;
			}
			if (score > 725)
			{
				return 2;
			}
			if (score > 650)
			{
				return 1;
			}
			return 0;
        }

        public override void OnGameOverAllSession()
        {
			base.OnGameOverAllSession();
        }
    }
}
