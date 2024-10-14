using UnityEngine;

namespace GAME
{
    public class LevelPreset : ScriptableObject
    {
        public int ID;
        public string Name;
        public Sprite Icon;
        public LevelRef Prefab;
    }
}

