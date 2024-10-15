using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class PlayerLogicHealth : MonoBehaviour
    {
        private void Awake()
        {
            PlayerSystem.Events.PlayerHealthChange += PlayerHealthChange;
            PlayerSystem.Events.PlayerDamage += PlayerDamage;
        }

        private void PlayerHealthChange(PlayerObject player, float value)
        {
            player.Health += value;
            
            if (player.Health > 0)
            {
                PlayerSystem.Events.PlayerChanged?.Invoke(player);
            }
            else
            {
                PlayerSystem.Events.PlayerDead?.Invoke(player);
            }
        }

        private void PlayerDamage(PlayerObject player, float damage)
        {
            SkillData skillShield = player.Buffs.Find(s => s.Preset.ID == 2);
            if (skillShield != null) damage -= skillShield.Preset.Value;
            if(damage <= 0) return;

            PlayerHealthChange(player, -damage);
        }
    }
}

