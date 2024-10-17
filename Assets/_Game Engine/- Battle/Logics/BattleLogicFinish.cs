using UnityEngine;

namespace GAME
{
    public class BattleLogicFinish : MonoBehaviour
    {
        private void Awake()
        {
            PlayerSystem.Events.PlayerDead += PlayerDead;
            BattleSystem.Events.BattleExit += BattleExit;
        }

        private void PlayerDead(PlayerObject player)
        {
            BattleSystem.Data.CurrentBattle.WinSide = player.Side == 1 ? 2 : 1;
            BattleSystem.Events.SetState?.Invoke(BattleSystem.Data.CurrentBattle, BattleState.Finish);
        }

        private void BattleExit(BattleData battle)
        {
            GameSystem.Events.GameActionWithFade?.Invoke(BattleClose, BattleNext);
        }

        private void BattleClose()
        {
            BattleData battle = BattleSystem.Data.CurrentBattle;
            
            foreach (PlayerObject player in battle.Players)
            {
                PlayerSystem.Events.PlayerClear?.Invoke(player);
            }

            Destroy(battle.Level.gameObject);
            BattleSystem.Data.CurrentBattle = null;
            BattleSystem.Data.Battles.Remove(battle);
        }

        private void BattleNext()
        {
            if(PlayerSystem.Data.CurrentPlayer.Side != 1) return; 
            PlayerSystem.Events.PlayerReady?.Invoke(PlayerSystem.Data.Players[0]);
        }
    }
}

