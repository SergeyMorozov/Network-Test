using UnityEngine;

namespace  GAME
{
    public class BattleLogicState : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.SetState += SetState;
        }

        private void SetState(BattleData battle, BattleState state)
        {
            if(battle.State == state) return;
            BattleState lastState = battle.State;
            battle.State = state;
            BattleSystem.Events.StateChanged?.Invoke(battle, lastState, state);
        }

    }
}

