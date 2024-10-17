using UnityEngine;

namespace GAME
{
    public class SkillLogic : MonoBehaviour
    {
        private void Awake()
        {
            BattleSystem.Events.MoveReady += MoveReady;
            SkillSystem.Events.SkillActive += SkillSendToNet;
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
                    if(buff.FX != null) Destroy(buff.FX);
                    player.Buffs.Remove(buff);
                    i--;
                }
            }
        }
        
        private void SkillSendToNet(BattleData battle, PlayerObject playerSource, PlayerObject playerTarget, SkillData skill)
        {
            NetCommand command = new NetCommand { Name = nameof(SkillData), ID = skill.Preset.ID };
            NetworkSystem.Events.SendCommand?.Invoke(command);
        }
    }
}

