using UnityEngine;

namespace GAME
{
    public class NetworkSystem : MonoBehaviour
    {
        private static NetworkSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<NetworkSystem>();
        }

        public static NetworkSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new NetworkSystemSettings());
            }
        }

        public static NetworkSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new NetworkSystemData());
            }
        }

        public static NetworkSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new NetworkSystemEvents());
            }
        }

        [SerializeField] private NetworkSystemSettings settings;
        [SerializeField] private NetworkSystemData data;
        private NetworkSystemEvents events;

    }
}

