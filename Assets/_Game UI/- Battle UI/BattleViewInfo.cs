using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class BattleViewInfo : MonoBehaviour
    {
        public Slider SliderHealth;
        public TextMeshProUGUI TextHealth;
        public BattleViewSkill SkillPrefab;
        public Transform Content;

        public List<BattleViewSkill> Buffs;
        public PlayerObject Player;
    }
}

