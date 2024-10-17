using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BattleLogicCreate : MonoBehaviour
    {
        private int _counter;
        
        private void Awake()
        {
            BattleSystem.Events.BattleCreate += BattleCreate;
        }

        private void BattleCreate(PlayerObject player, int levelID)
        {
            BattleData battle = new BattleData();
            BattleSystem.Data.CurrentBattle = battle;
            BattleSystem.Data.Battles.Add(battle);
            battle.Players = new List<PlayerObject> { player };

            _counter++;
            if (_counter > LevelSystem.Settings.Levels.Count) _counter = 1;

            LevelPreset levelPreset = levelID > 0
                ? LevelSystem.Settings.GetLevelByID(levelID)
                : LevelSystem.Settings.GetLevelByID(_counter);
            
            battle.Level = LevelSystem.Events.LevelCreate?.Invoke(levelPreset);
            LevelSystem.Events.SetPlayer?.Invoke(battle.Level, player);

            BattleSystem.Events.SetState?.Invoke(battle, BattleState.WaitEnemy);
        }
    }
}

