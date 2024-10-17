using UnityEngine;

namespace  GAME
{
    public class PlayerLogicClear : MonoBehaviour
    {
        private void Awake()
        {
            PlayerSystem.Events.PlayerClear += PlayerClear;
        }

        private void PlayerClear(PlayerObject player)
        {
            player.Buffs.Clear();
            player.PlayerTarget = null;
            player.Health = player.Preset.Health;
            foreach (SkillData skill in player.Skills)
            {
                Destroy(skill.FX);
                skill.MovesToRecovery = 0;
                skill.IsActive = true;
            }
            
            player.transform.SetParent(null);
            player.IsReadyForBattle = true;
        }
    }
}

