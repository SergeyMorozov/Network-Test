using UnityEngine;

namespace  GAME
{
    public class SkillLogicShield : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            if(skill.Preset.ID != 2) return;

            skill.MovesToRecovery = skill.Preset.TimeRestore;
            skill.IsActive = false;

            SkillData buff = new SkillData();
            buff.PlayerOwner = playerSource;
            buff.Preset = skill.Preset;
            buff.MovesToRemoveBuff = skill.Preset.TimeActive;
            playerSource.Buffs.Add(buff);
            
            BattleSystem.Events.MoveComplete?.Invoke(battle);
        }
    }
}

