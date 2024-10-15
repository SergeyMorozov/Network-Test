using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class BattleData
    {
        public BattlePreset Preset;

        public BattleState State;
        public List<PlayerObject> Players;
    }

    public enum BattleState
    {
        None = 0,
        WaitEnemy = 1,
        TurnSide1 = 2,
        TurnSide2 = 3,
        Finish = 4
    }
}

