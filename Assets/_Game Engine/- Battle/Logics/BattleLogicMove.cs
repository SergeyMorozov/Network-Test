using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class BattleLogicMove : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveComplete += MoveComplete;
        }

        private void MoveComplete(BattleData battle)
        {
            StartCoroutine(MoveNext(battle));
        }

        IEnumerator MoveNext(BattleData battle)
        {
            yield return new WaitForSeconds(0.5f);
            
            battle.MoveSide = battle.MoveSide == 1 ? 2 : 1;
            BattleSystem.Events.MoveNext?.Invoke(battle);
        }
    }
}

