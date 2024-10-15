using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class PlayerLogicDamage : MonoBehaviour
    {
        private void Awake()
        {
            PlayerSystem.Events.PlayerDamage += PlayerDamage;
        }

        private void PlayerDamage(PlayerObject player, float damage)
        {
            player.Health -= damage;

            if (player.Health > 0)
            {
                PlayerSystem.Events.PlayerChanged?.Invoke(player);
            }
            else
            {
                PlayerSystem.Events.PlayerDead?.Invoke(player);
            }
        }
    }
}

