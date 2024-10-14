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
            
        }
    }
}

