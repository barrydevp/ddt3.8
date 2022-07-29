using Game.Logic.AI;

namespace GameServerScript.AI.Game
{
    public class GuluKingdomSimpleGame : APVEGameControl
    {
        public override void OnCreated()
        {
			base.OnCreated();
			base.Game.SetupMissions("1071,1072");
			base.Game.TotalMissionCount = 2;
        }

        public override void OnPrepated()
        {
			base.OnPrepated();
			//base.Game.SessionId = 0;
        }

        public override int CalculateScoreGrade(int score)
        {
			base.CalculateScoreGrade(score);
			if (score > 800)
			{
				return 3;
			}
			if (score > 825)
			{
				return 2;
			}
			if (score > 725)
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
