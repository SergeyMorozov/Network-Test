using System;

namespace GAME
{
    [Serializable]
    public class PlayerSystemEvents
    {
        public Func<PlayerPreset, PlayerObject> CreatePlayer;
        public Action CreateLocalPlayer;
        public Action<PlayerObject> PlayerReady;
        public Action<PlayerObject, float> PlayerHealthChange;
        public Action<PlayerObject, float> PlayerDamage;
        public Action<PlayerObject> PlayerChanged;
        public Action<PlayerObject> PlayerDead;
        public Action<PlayerObject> PlayerClear;

        public Action<PlayerObject> AnimAttack;
        public Action<PlayerObject> AnimShield;
        public Action<PlayerObject> AnimHealth;
        public Action<PlayerObject> AnimFireball;
    }
}
