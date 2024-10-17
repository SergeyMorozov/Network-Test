using UnityEngine;

namespace  GAME
{
    public class LevelLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.SetPlayer += SetPlayer;
        }

        private void SetPlayer(LevelObject level, PlayerObject player)
        {
            player.transform.SetParent(level.Ref.PlayerSide[player.Side - 1], false);
            player.transform.localPosition = Vector3.zero;
            player.transform.localRotation = Quaternion.identity;
            CameraSystem.Events.SetCameraTarget?.Invoke(level.Ref.CameraSide[PlayerSystem.Data.CurrentPlayer.Side - 1]);
        }
    }
}

