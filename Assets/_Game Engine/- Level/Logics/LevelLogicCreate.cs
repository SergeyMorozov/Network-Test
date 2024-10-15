using UnityEngine;

namespace  GAME
{
    public class LevelLogicCreate : MonoBehaviour
    {
        private int _counter;
        
        private void Awake()
        {
            LevelSystem.Events.LevelCreate += LevelCreate;
        }

        private LevelObject LevelCreate(LevelPreset levelPreset)
        {
            LevelObject level = Tools.AddObject<LevelObject>(null);
            level.name = levelPreset.Name + " [" + ++_counter + "]";
            level.Preset = levelPreset;
            level.Ref = Tools.AddObject<LevelRef>(levelPreset.Prefab, level.transform);
            return level;
        }
    }
}

