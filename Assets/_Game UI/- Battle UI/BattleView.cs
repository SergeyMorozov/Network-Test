using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class BattleView : MonoBehaviour
    {
        public BattleViewSkill SkillPrefab;
        public Transform Content;
        public List<BattleViewInfo> PanelInfo;
        public CanvasGroup PanelBlocking;
        public Button ButtonExit;
    }
}

