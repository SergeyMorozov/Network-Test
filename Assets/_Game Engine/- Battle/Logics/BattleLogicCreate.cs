using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BattleLogicCreate : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.BattleCreate += BattleCreate;
        }

        private void BattleCreate(PlayerObject player)
        {
            BattleData battle = new BattleData();
            BattleSystem.Data.Battles.Add(battle);
            battle.Players = new List<PlayerObject> { player };
            player.Health = 50;

            LevelPreset levelPreset = Tools.GetRandomObject(LevelSystem.Settings.Levels);
            battle.Level = LevelSystem.Events.LevelCreate?.Invoke(levelPreset);
            LevelSystem.Events.SetPlayer?.Invoke(battle.Level, player);
            
            BattleSystem.Events.SetState?.Invoke(battle, BattleState.WaitEnemy);
        }
    }
}

