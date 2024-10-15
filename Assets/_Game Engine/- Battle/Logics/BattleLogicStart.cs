using UnityEngine;

namespace  GAME
{
    public class BattleLogicStart : MonoBehaviour
    {
        private void Awake()
        {
        }

        private void Update()
        {
            foreach (BattleData battle in BattleSystem.Data.Battles)
            {
                if(battle.State != BattleState.WaitEnemy) continue;

                PlayerObject player = PlayerSystem.Data.GetFreePlayer(battle.Players[0].Side);
                if(player == null) continue;
                
                battle.Players.Add(player);
                battle.MoveSide = 1;
                
                LevelSystem.Events.SetPlayer?.Invoke(battle.Level, player);
                BattleSystem.Events.SetState?.Invoke(battle, BattleState.Start);
            }
        }
    }
}

