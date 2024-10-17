using UnityEngine;

namespace GAME
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
                if (battle.State == BattleState.WaitEnemy)
                {
                    PlayerObject player = PlayerSystem.Data.GetEnemyPlayer(battle.Players[0].Side);
                    if (player == null) continue;

                    battle.Players.Add(player);
                    battle.MoveSide = 1;

                    LevelSystem.Events.SetPlayer?.Invoke(battle.Level, player);
                    BattleSystem.Events.SetState?.Invoke(battle, BattleState.Start);
                }

                if (battle.State == BattleState.Start)
                {
                    /*if (NetworkSystem.Data.ConnectMode == ConnectType.Host)
                    {
                        NetCommand command = new NetCommand { Name = "Battle", ID = battle.Level.Preset.ID };
                        NetworkSystem.Events.SendCommand?.Invoke(command);
                    }*/

                    BattleSystem.Events.SetState?.Invoke(battle, BattleState.Play);
                }
            }
        }
    }
}

