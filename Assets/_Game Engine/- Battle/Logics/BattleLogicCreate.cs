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

            LevelPreset levelPreset = Tools.GetRandomObject(LevelSystem.Settings.Levels);
            LevelObject level = LevelSystem.Events.LevelCreate?.Invoke(levelPreset);
            
            player.transform.SetParent(level.Ref.PlayerSide1, false);
            CameraSystem.Events.SetCameraTarget?.Invoke(level.Ref.CameraSide1);
            
            BattleSystem.Events.SetState?.Invoke(battle, BattleState.WaitEnemy);
        }
    }
}

