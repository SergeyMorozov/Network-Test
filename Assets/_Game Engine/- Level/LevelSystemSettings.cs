using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LevelSystemSettings : ScriptableObject
    {
        public List<LevelPreset> Levels;

        public LevelPreset GetLevelByID(int id) => Levels.Find(l => l.ID == id);
    }
}
