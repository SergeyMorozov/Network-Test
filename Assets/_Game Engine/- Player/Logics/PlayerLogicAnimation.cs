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
            
            PlayerSystem.Events.PlayerDead += PlayerDead;
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
                    GameObject fx = Tools.AddObject(skill.Preset.FX[0], playerSource.transform);
                    Destroy(fx, 3);
                    break;
            }
        }
        
        private void AnimAttack(PlayerObject player)
        {
            player.PlayerTarget.Ref.Animator.SetTrigger("Hit");
        }

        private void AnimShield(PlayerObject player)
        {
            SkillData skill = player.GetBuff(2);
            skill.FX = Tools.AddObject(skill.Preset.FX[0], player.transform);
        }

        private void AnimHealth(PlayerObject player)
        {
            SkillData skill = player.GetBuff(3);
            skill.FX = Tools.AddObject(skill.Preset.FX[0], player.transform);
        }

        private void AnimFireball(PlayerObject player)
        {
            SkillData skill = player.PlayerTarget.GetBuff(4);
            skill.FX = Tools.AddObject(skill.Preset.FX[1], player.PlayerTarget.transform);
            GameObject fx = Tools.AddObject(skill.Preset.FX[0], player.PlayerTarget.transform);
            Destroy(fx, 3);
        }

        private void PlayerDead(PlayerObject player)
        {
            player.Ref.Animator.SetTrigger("Die");
        }

    }
}

