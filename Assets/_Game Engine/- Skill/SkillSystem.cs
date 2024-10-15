using UnityEngine;

namespace GAME
{
    public class SkillSystem : MonoBehaviour
    {
        private static SkillSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<SkillSystem>();
        }

        public static SkillSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new SkillSystemSettings());
            }
        }

        public static SkillSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new SkillSystemData());
            }
        }

        public static SkillSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new SkillSystemEvents());
            }
        }

        [SerializeField] private SkillSystemSettings settings;
        [SerializeField] private SkillSystemData data;
        private SkillSystemEvents events;

    }
}

