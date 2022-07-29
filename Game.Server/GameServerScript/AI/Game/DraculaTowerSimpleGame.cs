using Game.Logic.AI;

namespace GameServerScript.AI.Game
{
    public class DraculaTowerSimpleGame : APVEGameControl
    {
        public override void OnCreated()
        {
			base.Game.SetupMissions("700,701");
			base.Game.TotalMissionCount = 1;
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
        }
    }
}
