using System;

namespace GAME
{
    [Serializable]
    public class LevelSystemEvents
    {
        public Func<LevelPreset, LevelObject> LevelCreate;
        public Action<LevelObject, PlayerObject> SetPlayer;
    }
}
