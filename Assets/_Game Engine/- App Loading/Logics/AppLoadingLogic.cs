using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using YG;

namespace  GAME
{
    public class AppLoadingLogic : MonoBehaviour
    {
        private AppLoadingSystemData _data;
        private bool _isLoadingComplete;
        private Func<bool> _actionCheck;
        private Action _actionComplete;
        private bool _useFade;
        private bool _noClose;
        private bool _nextStep;

        private void Awake()
        {
            _data = AppLoadingSystem.Data;
            
            AppLoadingSystem.Events.AppLoad += AppLoad;
        }

        private void AppLoad()
        {
            StartCoroutine(TimeLineLoading());
        }

        IEnumerator TimeLineLoading()
        {
            _data.IsActive = true;
            _data.ShowUI = true;
            _useFade = true;

            _data.Value = 0;
            _data.ValueStep = 0;
            
            // Settings
            _nextStep = false;
            yield return new WaitForSeconds(0.1f);
            
            // Load complete
            _data.ValueStep = 1f;
            _nextStep = false;
        }

        private void NextStep()
        {
            _nextStep = true;
        }

        private void Update()
        {
            if (!_data.IsActive || !_data.ShowUI || _data.Value >= 1) return;

            _data.Value += Time.deltaTime / AppLoadingSystem.Settings.FakeTimeLoading;

            if (_data.Value < _data.ValueStep) return;
            _data.Value = _data.ValueStep;

            if (_data.Value >= 1)
                GameSystem.Events.GameActionWithFade?.Invoke(Close, MainMenuCanvas.Instance.Show);
        }

        private void Close()
        {
            _data.IsActive = false;
            _data.ShowUI = false;
        }
        
    }
}

