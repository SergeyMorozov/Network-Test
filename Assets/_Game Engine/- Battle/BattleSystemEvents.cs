using System;

namespace GAME
{
    [Serializable]
    public class BattleSystemEvents
    {
        public Action<PlayerObject> BattleCreate;
        public Action<BattleData, BattleState> SetState;
        public Action<BattleData, BattleState, BattleState> StateChanged;

        public Action<BattleData> MoveComplete;
        public Action<BattleData> MoveNext;
        public Action<BattleData> BattleExit;
    }
}
