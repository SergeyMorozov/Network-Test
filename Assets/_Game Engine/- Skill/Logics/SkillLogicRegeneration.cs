using UnityEngine;

namespace  GAME
{
    public class SkillLogicRegeneration : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
            BattleSystem.Events.CalculateBuffs += CalculateBuffs;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            if(skill.Preset.ID != 3) return;

            skill.MovesToRecovery = skill.Preset.TimeRestore;
            PlayerSystem.Events.PlayerHealthChange?.Invoke(playerSource, skill.Preset.Value);
            
            SkillData buff = new SkillData();
            buff.PlayerOwner = playerSource;
            buff.Preset = skill.Preset;
            buff.MovesToRemoveBuff = skill.Preset.TimeActive;
            playerSource.Buffs.Add(buff);
            
            BattleSystem.Events.MoveComplete?.Invoke(battle);
        }
        
        private void CalculateBuffs(BattleData battle)
        {
            foreach (PlayerObject player in battle.Players)
            {
                if(player.Side != battle.MoveSide) continue;
                
                foreach (SkillData buff in player.Buffs)
                {
                    if(buff.Preset.ID != 3) continue;
                    
                    PlayerSystem.Events.PlayerHealthChange?.Invoke(player, buff.Preset.ValueActive);
                    buff.MovesToRemoveBuff--;
                }
            }
        }


    }
}

