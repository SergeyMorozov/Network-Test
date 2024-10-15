using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class BattleData
    {
        public BattlePreset Preset;

        public int TurnSide;
        public BattleState State;
        public LevelObject Level;
        public List<PlayerObject> Players;
    }

    public enum BattleState
    {
        None = 0,
        WaitEnemy = 1,
        Start = 2,
        Play = 3,
        Finish = 4
    }
}

