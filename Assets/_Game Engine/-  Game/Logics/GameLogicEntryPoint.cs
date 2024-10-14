﻿using UnityEngine;
//using YG;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class GameLogicEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Random.InitState(2);
            
            Application.targetFrameRate = 1000;
            GameSystem.Data.GamePause = true;
            
            GameSystem.Events.GameStart += GameStart;
        }

        private void Start()
        {
            AppLoadingSystem.Events.AppLoad?.Invoke();
        }

        private void GameStart()
        {
            GameSystem.Data.GamePause = false;
            GameSystem.Data.GamePlaying = true;
        }

        private void Update()
        {
            if(GameSystem.Data.GamePause || !GameSystem.Data.GamePlaying) return;
            GameSystem.Data.TimeGamePlay += Time.deltaTime;
        }

        /*
       private void OnApplicationPause(bool pauseStatus)
        {
            if (GameSystem.Data.GamePause != pauseStatus)
            {
                GameSystem.Data.GamePause = pauseStatus;
            }
        }
        */

    }
}

