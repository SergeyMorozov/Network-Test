using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class PlayerObject : MonoBehaviour
    {
        public PlayerPreset Preset;
        public PlayerRef Ref;

        [Header("Data ___")] public PlayerObject PlayerTarget;
        public int Side;
        public bool IsReadyForBattle;
        public float Health;
        public List<SkillData> Skills;
        public List<SkillData> Buffs;

        public SkillData GetBuff(int id) => Buffs.Find(b => b.Preset.ID == id);

    }
}

