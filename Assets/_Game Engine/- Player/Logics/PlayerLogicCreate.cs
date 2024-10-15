using UnityEngine;

namespace  GAME
{
    public class PlayerLogicCreate : MonoBehaviour
    {
        private int _counter;
        
        private void Awake()
        {
            PlayerSystem.Events.CreatePlayer += CreatePlayer;
        }

        private PlayerObject CreatePlayer(PlayerPreset playerPreset)
        {
            PlayerObject player = Tools.AddObject<PlayerObject>(null);
            player.name = playerPreset.Name + " [" + ++_counter + "]";
            player.Preset = playerPreset;
            player.Ref = Tools.AddObject<PlayerRef>(playerPreset.Prefab, player.transform);
            PlayerSystem.Data.Players.Add(player);
            return player;
        }
    }
}

