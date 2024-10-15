using UnityEngine;

namespace  GAME
{
    public class SkillLogicRegeneration : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
            BattleSystem.Events.MoveNext += MoveNext;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            if(skill.Preset.ID != 3) return;

            skill.MovesToRecovery = skill.Preset.TimeRestore;
            PlayerSystem.Events.PlayerHealthChange?.Invoke(playerSource, skill.Preset.Value);
            
            SkillData buff = new SkillData();
            buff.Preset = skill.Preset;
            buff.MovesToRemoveBuff = skill.Preset.TimeActive;
            playerSource.Buffs.Add(buff);
            
            BattleSystem.Events.MoveComplete?.Invoke(battle);
        }
        
        private void MoveNext(BattleData battle)
        {
            foreach (PlayerObject player in battle.Players)
            {
                if(player.Side != battle.MoveSide) continue;
                
                foreach (SkillData skill in player.Buffs)
                {
                    if(skill.Preset.ID != 3) continue;
                    PlayerSystem.Events.PlayerHealthChange?.Invoke(player, skill.Preset.ValueActive);
                }
            }
        }


    }
}

