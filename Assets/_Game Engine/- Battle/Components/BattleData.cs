using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class BattleData
    {
        public BattlePreset Preset;

        public int MoveSide;
        public BattleState State;
        public LevelObject Level;
        public List<PlayerObject> Players;

        public PlayerObject PlayerSource => Players.Find(p => p.Side == MoveSide);
        public PlayerObject PlayerTarget => Players.Find(p => p.Side != MoveSide);
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

