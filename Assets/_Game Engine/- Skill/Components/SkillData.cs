using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class SkillData
    {
        public SkillPreset Preset;

        public bool IsActive;
        public int MovesToRecovery;
        public int MovesToRemoveBuff;
        public PlayerObject PlayerOwner;
        public GameObject FX;
    }
}

