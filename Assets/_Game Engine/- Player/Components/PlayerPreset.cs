using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class PlayerPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public PlayerRef Prefab;

        [Space]
        public float Health;
        public List<SkillPreset> Skills;
    }
}

