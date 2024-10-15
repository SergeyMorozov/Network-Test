using UnityEngine;

namespace GAME
{
    public class SkillLogic : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveNext += MoveNext;
        }

        private void MoveNext(BattleData battle)
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

                for (var i = 0; i < player.Buffs.Count; i++)
                {
                    var buff = player.Buffs[i];
                    buff.MovesToRemoveBuff--;
                    if (buff.MovesToRemoveBuff != 0) continue;

                    player.Buffs.Remove(buff);
                    i--;
                }
            }
        }

    }
}

