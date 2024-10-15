using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class BattleData
    {
        public BattlePreset Preset;

        public List<PlayerObject> Players;
    }
}

