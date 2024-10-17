using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class PlayerLogicCreate : MonoBehaviour
    {
        private int _counter;
        
        private void Awake()
        {
            GameSystem.Events.GameStart += GameStart;
            
            PlayerSystem.Events.CreatePlayer += CreatePlayer;
            PlayerSystem.Events.CreateLocalPlayer += CreateLocalPlayer;
        }

        private void GameStart()
        {
            PlayerObject player1 = CreatePlayer(PlayerSystem.Settings.PlayerHost);
            player1.Side = 1;
            player1.IsReadyForBattle = true;
            PlayerSystem.Data.CurrentPlayer = player1;
            PlayerSystem.Events.PlayerReady?.Invoke(player1);

            PlayerSystem.Events.CreateLocalPlayer?.Invoke();
        }

        private PlayerObject CreatePlayer(PlayerPreset playerPreset)
        {
            PlayerObject player = Tools.AddObject<PlayerObject>(null);
            player.name = playerPreset.Name + " [" + ++_counter + "]";
            player.Preset = playerPreset;
            player.Ref = Tools.AddObject<PlayerRef>(playerPreset.Prefab, player.transform);

            player.Health = player.Preset.Health;
            
            player.Skills = new List<SkillData>();
            foreach (SkillPreset skillPreset in playerPreset.Skills)
            {
                SkillData skill = new SkillData { Preset = skillPreset, IsActive = true };
                player.Skills.Add(skill);
            }
            
            player.Buffs = new List<SkillData>();
            
            PlayerSystem.Data.Players.Add(player);
            return player;
        }

        private void CreateLocalPlayer()
        {
            PlayerPreset playerPreset = PlayerSystem.Settings.PlayerClient;
            PlayerObject player = PlayerSystem.Events.CreatePlayer?.Invoke(playerPreset);
            player.Side = 2;
            player.IsReadyForBattle = true;
        }
    }
}

