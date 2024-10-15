using System;

namespace GAME
{
    [Serializable]
    public class LevelSystemEvents
    {
        public Func<LevelPreset, LevelObject> LevelCreate;
    }
}
