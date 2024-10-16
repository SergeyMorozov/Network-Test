using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class PlayerSystemData
    {
        public PlayerObject CurrentPlayer;
        public List<PlayerObject> Players;

        public PlayerObject GetEnemyPlayer(int sideEnemy)
        {
            return Players.Find(p => p.Side != sideEnemy);
        }
    }
}
