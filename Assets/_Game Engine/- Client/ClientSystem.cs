using UnityEngine;

namespace GAME
{
    public class ClientSystem : MonoBehaviour
    {
        private static ClientSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<ClientSystem>();
        }

        public static ClientSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new ClientSystemSettings());
            }
        }

        public static ClientSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new ClientSystemData());
            }
        }

        public static ClientSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new ClientSystemEvents());
            }
        }

        [SerializeField] private ClientSystemSettings settings;
        [SerializeField] private ClientSystemData data;
        private ClientSystemEvents events;

    }
}

