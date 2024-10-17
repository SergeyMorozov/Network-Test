using Photon.Chat;
using UnityEngine;

namespace  GAME
{
    public class NetworkLogicOnGet : MonoBehaviour
    {
        private bool _enemyOnline;
        private bool _enemyInited;
        private BattleData _battle;

        private void Awake()
        {
            _enemyOnline = true;
            
            NetworkSystem.Events.ConnectComplete += ConnectComplete;
            NetworkSystem.Events.OnGetCommand += OnGetCommand;
            PlayerSystem.Events.CreateLocalPlayer += CreateLocalPlayer;
        }

        private void CreateLocalPlayer()
        {
            _enemyOnline = false;
        }

        private void ConnectComplete()
        {
        }

        private void OnGetCommand(string sender, string json)
        {
            if(!_enemyOnline) return;
            
            NetData data = JsonUtility.FromJson<NetData>(json);
            if (data.host != NetworkSystem.Data.HostName) return;

            if (!_enemyInited)
            {
                EnemyInit();
            }

            NetCommand command = JsonUtility.FromJson<NetCommand>(data.json);

            if (command.Name == "Battle" && sender != NetworkSystem.Data.UserName)
            {
                BattleSystem.Events.BattleCreate?.Invoke(PlayerSystem.Data.CurrentPlayer, command.ID);
            }

            if (command.Name == nameof(SkillData))
            {
                _battle = BattleSystem.Data.CurrentBattle;
                SkillData skill = _battle.PlayerSource.Skills.Find(s => s.Preset.ID == command.ID);
                SkillSystem.Events.SkillActive?.Invoke(_battle, _battle.PlayerSource, _battle.PlayerTarget, skill);
            }

        }

        private void EnemyInit()
        {
            if(PlayerSystem.Data.CurrentPlayer.Side == 1)
            {
                PlayerPreset playerPreset = PlayerSystem.Settings.PlayerClient;
                PlayerObject player = PlayerSystem.Events.CreatePlayer?.Invoke(playerPreset);
                player.Side = 2;
                player.IsReadyForBattle = true;
            }
            else
            {
                PlayerPreset playerPreset = PlayerSystem.Settings.PlayerHost;
                PlayerObject player = PlayerSystem.Events.CreatePlayer?.Invoke(playerPreset);
                player.Side = 1;
                player.IsReadyForBattle = true;
            }
            _enemyInited = true;
        }

    }
}

