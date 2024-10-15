using System;

namespace GAME
{
    [Serializable]
    public class PlayerSystemEvents
    {
        public Func<PlayerPreset, PlayerObject> CreatePlayer;
        public Action<PlayerObject> PlayerReady;
        public Action<PlayerObject, float> PlayerDamage;
        public Action<PlayerObject> PlayerChanged;
        public Action<PlayerObject> PlayerDead;
    }
}
