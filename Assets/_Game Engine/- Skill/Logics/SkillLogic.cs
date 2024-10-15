using UnityEngine;

namespace GAME
{
    public class SkillLogic : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveReady += MoveReady;
        }

        private void MoveReady(BattleData battle)
        {
            foreach (PlayerObject player in battle.Players)
            {
                if (player.Side != battle.MoveSide) continue;

                foreach (SkillData skill in player.Skills)
                {
                    if (skill.MovesToRecovery == 0) continue;

                    skill.MovesToRecovery--;
                    skill.IsActive = skill.MovesToRecovery == 0;
                }
            }
            
            foreach (PlayerObject player in battle.Players)
            {
                for (var i = 0; i < player.Buffs.Count; i++)
                {
                    var buff = player.Buffs[i];
                    if (buff.MovesToRemoveBuff != 0) continue;
                    player.Buffs.Remove(buff);
                    i--;
                }
            }
        }

    }
}

