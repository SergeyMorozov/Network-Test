using UnityEngine;

namespace GAME
{
    public class BattleSystem : MonoBehaviour
    {
        private static BattleSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<BattleSystem>();
        }

        public static BattleSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new BattleSystemSettings());
            }
        }

        public static BattleSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new BattleSystemData());
            }
        }

        public static BattleSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new BattleSystemEvents());
            }
        }

        [SerializeField] private BattleSystemSettings settings;
        [SerializeField] private BattleSystemData data;
        private BattleSystemEvents events;

    }
}

