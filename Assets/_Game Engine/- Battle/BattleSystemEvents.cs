using System;

namespace GAME
{
    [Serializable]
    public class BattleSystemEvents
    {
        public Action<PlayerObject, int> BattleCreate;
        public Action<BattleData, BattleState> SetState;
        public Action<BattleData, BattleState, BattleState> StateChanged;

        public Action<BattleData> MoveComplete;
        public Action<BattleData> CalculateBuffs;
        public Action<BattleData> MoveReady;
        public Action<BattleData> BattleExit;
    }
}
