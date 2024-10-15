using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class PlayerLogicAI : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveReady += MoveReady;
        }

        private void MoveReady(BattleData battle)
        {
            if(battle.MoveSide != battle.Players[1].Side) return;

            StartCoroutine(CastSkill(battle, battle.Players[1]));
        }

        IEnumerator CastSkill(BattleData battle, PlayerObject player)
        {
            yield return new WaitForSeconds(1f);

            SkillData skill = Tools.GetRandomObject(player.Skills);
            if (!skill.IsActive)
            {
                skill = player.Skills[0];
            }
            
            Debug.Log("EnemySkill " + skill.Preset.Name);
            SkillSystem.Events.SkillActive?.Invoke(battle, battle.PlayerSource, battle.PlayerTarget, skill);
        }
    }
}

