using UnityEngine;

namespace  GAME
{
    public class SkillLogicClear : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            if(skill.Preset.ID != 5) return;

            skill.MovesToRecovery = skill.Preset.TimeRestore;

            for (var i = 0; i < playerSource.Buffs.Count; i++)
            {
                var buff = playerSource.Buffs[i];
                if(buff.PlayerOwner == playerSource) continue;
                if(buff.FX != null) Destroy(buff.FX);
                playerSource.Buffs.Remove(buff);
                i--;
            }
            
            BattleSystem.Events.MoveComplete?.Invoke(battle);
        }
    }
}

