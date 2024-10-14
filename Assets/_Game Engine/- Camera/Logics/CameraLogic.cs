using System;
using Unity.Cinemachine;
using UnityEngine;

namespace  GAME
{
    public class CameraLogic : MonoBehaviour
    {
        private CameraObject _camera;
        private CinemachineCamera _cinemachine;

        private void Awake()
        {
            _camera = CameraSystem.Data.CurrentCamera;
            _cinemachine = _camera.Ref.Cinemachine;

            CameraSystem.Events.SetCameraTarget += SetCameraTarget;
        }

        private void SetCameraTarget(Transform target)
        {
            _cinemachine.Target.TrackingTarget = target;
        }

        
    }
}

