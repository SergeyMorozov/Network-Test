using UnityEngine;

namespace  GAME
{
    public class WorldLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            WorldSystem.Events.WorldInit += WorldInit;
        }
        
        private void WorldInit()
        {
            WorldSystem.Events.WorldInitComplete?.Invoke();
        }

    }
}

