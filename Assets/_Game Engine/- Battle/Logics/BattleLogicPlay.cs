using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class BattleLogicPlay : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveComplete += MoveComplete;
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
        
        

    }
}

