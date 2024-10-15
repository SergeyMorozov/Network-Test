using System;

namespace GAME
{
    [Serializable]
    public class PlayerSystemEvents
    {
        public Action<PlayerPreset> CreatePlayer;
        public Action<PlayerObject> PlayerReady;
    }
}
