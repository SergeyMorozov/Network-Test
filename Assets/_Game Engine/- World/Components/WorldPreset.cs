using UnityEngine;

namespace GAME
{
    public class WorldPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public WorldRef Prefab;

        public SoundPreset SoundOcean;
    }
}

