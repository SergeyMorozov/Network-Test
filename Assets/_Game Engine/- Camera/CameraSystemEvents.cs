using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class CameraSystemEvents
    {
        public Action<Vector3> SetCameraPoint;
        public Action<Transform> SetCameraTarget;
        public Action<int> SetCameraIndex;
    }
}
