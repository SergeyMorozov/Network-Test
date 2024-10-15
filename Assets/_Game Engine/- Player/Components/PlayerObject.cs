using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class PlayerObject : MonoBehaviour
    {
        public PlayerPreset Preset;
        public PlayerRef Ref;

        public int Side;
        public bool IsReadyForBattle;
        public float Health;
        public List<SkillData> Skills;
    }
}

