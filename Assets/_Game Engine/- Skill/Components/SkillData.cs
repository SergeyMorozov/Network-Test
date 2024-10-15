using System;

namespace GAME
{
    [Serializable]
    public class SkillData
    {
        public SkillPreset Preset;

        public bool IsActive;
        public int MovesToRecovery;
    }
}

