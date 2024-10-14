using UnityEngine;

namespace GAME
{
    public class HostSystem : MonoBehaviour
    {
        private static HostSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<HostSystem>();
        }

        public static HostSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new HostSystemSettings());
            }
        }

        public static HostSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new HostSystemData());
            }
        }

        public static HostSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new HostSystemEvents());
            }
        }

        [SerializeField] private HostSystemSettings settings;
        [SerializeField] private HostSystemData data;
        private HostSystemEvents events;

    }
}

