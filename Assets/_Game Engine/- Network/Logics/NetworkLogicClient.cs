using UnityEngine;

namespace  GAME
{
    public class NetworkLogicClient : MonoBehaviour
    {
        private void Awake()
        {
            NetworkSystem.Events.StartClient += StartClient;
        }

        private void StartClient(string hostName)
        {
            NetworkSystem.Data.ConnectMode = ConnectType.Client;
            NetworkSystem.Data.HostName = hostName.Replace(" ", "_");
            NetworkSystem.Data.UserName = "Client";
            NetworkSystem.Events.Connect?.Invoke();
            
            NetworkSystem.Events.ConnectComplete += ConnectComplete;
        }
        
        private void ConnectComplete()
        {
            PlayerSystem.Events.CreatePlayer?.Invoke(PlayerSystem.Settings.PlayerClient);
            PlayerSystem.Data.CurrentPlayer = PlayerSystem.Data.Players[0];
            PlayerSystem.Data.CurrentPlayer.Side = 2;
            PlayerSystem.Events.PlayerReady?.Invoke(PlayerSystem.Data.CurrentPlayer);
        }


    }
}

