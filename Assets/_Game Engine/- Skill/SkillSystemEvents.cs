using System;

namespace GAME
{
    [Serializable]
    public class SkillSystemEvents
    {
        public Action<SkillData> SkillActive;
    }
}
