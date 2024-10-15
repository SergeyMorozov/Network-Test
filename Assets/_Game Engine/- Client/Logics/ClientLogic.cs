using UnityEngine;

namespace  GAME
{
    public class ClientLogic : MonoBehaviour
    {
        private void Awake()
        {
            ClientSystem.Events.StartClient += StartClient;
        }

        private void StartClient(string hostName)
        {
            NetworkSystem.Data.ConnectType = ConnectType.Client;
            
            PlayerSystem.Events.CreatePlayer?.Invoke(PlayerSystem.Settings.PlayerClient);
            PlayerSystem.Data.CurrentPlayer = PlayerSystem.Data.Players[0];
            PlayerSystem.Data.CurrentPlayer.Side = 2;
            PlayerSystem.Events.PlayerReady?.Invoke(PlayerSystem.Data.CurrentPlayer);
        }
    }
}

