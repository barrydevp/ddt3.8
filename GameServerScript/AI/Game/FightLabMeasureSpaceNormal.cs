using System;
using System.Collections.Generic;
using System.Text;
using Game.Logic.AI;

namespace GameServerScript.AI.Game
{
    public class FightLabMeasureSpaceNormal : APVEGameControl
    {
        public override void OnCreated()
        {
            Game.SetupMissions("111");
            Game.TotalMissionCount = 1;
        }

        public override void OnPrepated()
        {
            Game.SessionId = 0;
        }

        public override int CalculateScoreGrade(int score)
        {
            if (score > 800)
            {
                return 3;
            }
            else if (score > 725)
            {
                return 2;
            }
            else if (score > 650)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override void OnGameOverAllSession()
        {
        }
    }
}
