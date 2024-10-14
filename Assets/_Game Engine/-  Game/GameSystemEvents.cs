using System;

namespace GAME
{
    [Serializable]
    public class GameSystemEvents
    {
        public Action<Action, Action> GameActionWithFade;
        
        public Action GameMainMenuShow;
        public Action GameMainMenuHide;
        public Action<string> GameModeHost;
        public Action<string> GameModeClient;
        public Action GameStart;
        public Action GameInit;
        public Action GameReady;
    }
}