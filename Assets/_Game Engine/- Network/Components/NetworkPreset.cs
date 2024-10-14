using UnityEngine;

namespace GAME
{
    public class NetworkPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public NetworkRef Prefab;
    }
}

