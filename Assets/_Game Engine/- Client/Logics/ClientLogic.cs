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
            
        }
    }
}

