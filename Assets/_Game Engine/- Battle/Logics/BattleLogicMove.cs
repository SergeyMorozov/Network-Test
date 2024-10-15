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
            // battle.MoveSide = battle.MoveSide == 1 ? 2 : 1;
            BattleSystem.Events.MoveNext?.Invoke(battle);
        }
    }
}

