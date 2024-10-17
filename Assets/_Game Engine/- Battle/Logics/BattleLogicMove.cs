using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class BattleLogicMove : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveComplete += MoveComplete;
            PlayerSystem.Events.PlayerDead += PlayerDead;
        }

        private void MoveComplete(BattleData battle)
        {
            StartCoroutine(CalculateBuffs(battle));
        }

        IEnumerator CalculateBuffs(BattleData battle)
        {
            yield return new WaitForSeconds(1f);
            
            battle.MoveSide = battle.MoveSide == 1 ? 2 : 1;
            BattleSystem.Events.CalculateBuffs?.Invoke(battle);
            
            yield return new WaitForSeconds(1f);
            BattleSystem.Events.MoveReady?.Invoke(battle);
        }
        
        private void PlayerDead(PlayerObject player)
        {
            BattleSystem.Data.CurrentBattle.WinSide = player.Side == 1 ? 2 : 1;
            BattleSystem.Events.SetState?.Invoke(BattleSystem.Data.CurrentBattle, BattleState.Finish);
        }

    }
}

