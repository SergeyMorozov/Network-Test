using System;

namespace GAME
{
    [Serializable]
    public class SkillSystemEvents
    {
        public Action<BattleData, PlayerObject, PlayerObject, SkillData> SkillActive;
    }
}
