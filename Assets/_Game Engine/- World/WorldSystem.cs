using UnityEngine;

namespace GAME
{
    public class WorldSystem : MonoBehaviour
    {
        private static WorldSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<WorldSystem>();
        }

        public static WorldSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new WorldSystemSettings());
            }
        }

        public static WorldSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new WorldSystemData());
            }
        }

        public static WorldSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new WorldSystemEvents());
            }
        }

        [SerializeField] private WorldSystemSettings settings;
        [SerializeField] private WorldSystemData data;
        private WorldSystemEvents events;

    }
}

