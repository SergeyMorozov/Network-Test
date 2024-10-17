using System.Collections.Generic;
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
        public CanvasGroup PanelWait;
        public Transform IconWait;
        public GameObject PanelVictory;
        public GameObject PanelDefeat;
        public Button ButtonExit;
        // public Button ButtonCreatePlayer;
        public Button ButtonNext;
    }
}

