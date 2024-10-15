using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class SkillPreset : ScriptableObject
    {
        public int ID;
        public string Name;
        public Sprite Icon;
        public SkillRef Prefab;

        [Space]
        public SkillTarget TargetUse;
        public float Value;
        public float ValueActive;
        public int TimeActive;
        public int TimeRestore;
        
        [Space]
        public List<GameObject> FX;
    }

    public enum SkillTarget
    {
        None = 0,
        OnYourself = 1,
        OnEnemy = 2,
        OnFriend = 3,
        OnAnyTarget = 4,
        OnArea = 5,
    }
}

