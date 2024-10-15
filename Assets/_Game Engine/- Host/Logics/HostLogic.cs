using UnityEngine;

namespace  GAME
{
    public class HostLogic : MonoBehaviour
    {
        private void Awake()
        {
            HostSystem.Events.StartHost += StartHost;
        }

        private void StartHost(string hostName)
        {
            NetworkSystem.Data.ConnectType = ConnectType.Host;
            
            PlayerSystem.Events.CreatePlayer?.Invoke(PlayerSystem.Settings.PlayerHost);
            PlayerSystem.Data.CurrentPlayer = PlayerSystem.Data.Players[0];
            PlayerSystem.Data.CurrentPlayer.Side = 1;
            PlayerSystem.Events.PlayerReady?.Invoke(PlayerSystem.Data.CurrentPlayer);
        }
    }
}

