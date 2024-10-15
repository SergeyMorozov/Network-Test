using System;

namespace GAME
{
    [Serializable]
    public class PlayerSystemEvents
    {
        public Func<PlayerPreset, PlayerObject> CreatePlayer;
        public Action<PlayerObject> PlayerReady;
    }
}
