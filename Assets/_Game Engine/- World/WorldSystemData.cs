using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class WorldSystemData
    {
        public WorldObject World;
        public Transform Water;

        public GameObject StartWorld;
    }

    [Serializable]
    public class WaterPoint
    {
        public Vector3 Position;
        public Vector3 Normal;
    }
}
