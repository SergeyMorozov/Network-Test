using UnityEngine;

namespace  GAME
{
    public class BattleLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            PlayerSystem.Events.PlayerReady += PlayerReady;
        }

        private void PlayerReady(PlayerObject player)
        {
            if (player == PlayerSystem.Data.CurrentPlayer && player.Side == 1)
            {
                BattleSystem.Events.BattleCreate?.Invoke(player, 0);
            }
        }
    }
}

