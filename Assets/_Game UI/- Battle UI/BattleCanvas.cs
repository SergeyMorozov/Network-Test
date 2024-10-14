using System;
using UnityEngine;

namespace GAME
{
    public class BattleCanvas : MonoBehaviour
    {
        private static BattleCanvas _instance;

        public static BattleCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<BattleCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public BattleView View;
    }
}

