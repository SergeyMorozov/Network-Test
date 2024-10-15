using UnityEngine;

namespace  GAME
{
    public class PlayerLogicAnimation : MonoBehaviour
    {
        private void Awake()
        {
            SkillSystem.Events.SkillActive += SkillActive;
            
            PlayerSystem.Events.AnimAttack += AnimAttack;
            PlayerSystem.Events.AnimShield += AnimShield;
            PlayerSystem.Events.AnimHealth += AnimHealth;
            PlayerSystem.Events.AnimFireball += AnimFireball;
        }

        private void SkillActive(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            playerSource.PlayerTarget = playerTarget;
            
            switch (skill.Preset.ID)
            {
                case 1:
                    playerSource.Ref.Animator.SetTrigger("Attack");
                    break;
                
                case 2:
                    playerSource.Ref.Animator.SetTrigger("Shield");
                    break;

                case 3:
                    playerSource.Ref.Animator.SetTrigger("Health");
                    break;
                
                case 4:
                    playerSource.Ref.Animator.SetTrigger("Fireball");
                    break;

                case 5:
                    playerSource.Ref.Animator.SetTrigger("Clear");
                    break;
            }
        }
        
        private void AnimAttack(PlayerObject player)
        {
            player.PlayerTarget.Ref.Animator.SetTrigger("Hit");
        }

        private void AnimShield(PlayerObject player)
        {
            
        }

        private void AnimHealth(PlayerObject player)
        {
            
        }

        private void AnimFireball(PlayerObject player)
        {
            
        }


    }
}

