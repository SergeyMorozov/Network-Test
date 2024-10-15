using UnityEngine;

namespace  GAME
{
    public class SkillLogicAttack : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            if(skill.Preset.ID != 1) return;

            skill.MovesToRecovery = skill.Preset.TimeRestore;
            
            PlayerSystem.Events.PlayerDamage?.Invoke(playerTarget, skill.Preset.Value);
            BattleSystem.Events.MoveComplete?.Invoke(battle);
        }
    }
}

