using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class WorldSystemEvents
    {
        public Action WorldNew;
        public Action WorldNewLoaded;
        public Action WorldInit;
        public Action WorldInitComplete;
        public Func<Vector3, WaterPoint> GetWaterPoint;
        public Func<Vector3, Vector3> GetWaterPosition;
        public Func<Vector3, Vector3, Vector3, Vector3> GetWaterNormal;
    }
}
