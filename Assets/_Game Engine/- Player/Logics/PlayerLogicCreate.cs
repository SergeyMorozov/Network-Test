using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class PlayerLogicCreate : MonoBehaviour
    {
        private int _counter;
        
        private void Awake()
        {
            PlayerSystem.Events.CreatePlayer += CreatePlayer;
            PlayerSystem.Events.CreateLocalPlayer += CreateLocalPlayer;
            BattleSystem.Events.StateChanged += StateChanged;
        }

        private void StateChanged(BattleData arg1, BattleState arg2, BattleState arg3)
        {
            
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

