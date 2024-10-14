using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class FXUILogic : MonoBehaviour
    {
        private FXView _view;
        private bool _show;
        private Camera _camera;
        private Camera _cameraUI;
        private RectTransform _canvas;

        public float Delay;
        public float Speed1;
        public float Speed2;
        
        [Serializable]
        public class FXTask
        {
            public FXMoney FXMoney;
            public Vector2 Source;
            public int TargetIndex;
            public List<Vector2> Targets;
            public int Value;
            public float Speed;
            public float Dist;
        }
        
        public List<FXTask> _tasks;

        private void Awake()
        {
            _view = FXCanvas.Instance.View;
            _view.FXMoney.gameObject.SetActive(false);
            _tasks = new List<FXTask>();

            _camera = Camera.main;
            _cameraUI = UISystem.Data.CameraUI;
            _canvas = UISystem.Data.MainCanvas;

            // PlayerSystem.Events.MoneyOnScreenAdd += MoneyOnScreenAdd;
        }

        private void MoneyOnScreenAdd(Transform position, float money)
        {
            Vector2 v1 = GetPositionScreen(position);
            
            for (int i = 0; i < money; i++)
            {
                Vector2 v2 = v1 + Random.insideUnitCircle * 200;
                StartMove(v1, v2, 1);
            }
        }
        
        private void StartMove(Vector2 source, Vector2 target, int value)
        {
            FXTask task = new FXTask()
            {
                Source = source,
                Targets = new List<Vector2>(),
                Value = value,
                Speed = Speed1 * Random.Range(0.8f, 1.2f),
                Dist = 0
            };

            task.Targets.Add(target);
            // task.Targets.Add(GetPositionScreenUI(LevelCanvas.Instance.View.IconMoney.transform));
            
            task.FXMoney = Tools.AddUI<FXMoney>(_view.FXMoney, _view.transform);
            task.FXMoney.RectTransform.anchoredPosition = source;

            _tasks.Add(task);
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }

        private void Update()
        {
            for (var index = 0; index < _tasks.Count; index++)
            {
                var task = _tasks[index];
                // task.FXMoney.RectTransform.anchoredPosition = Vector2.Lerp(task.FXMoney.RectTransform.anchoredPosition, task.Target, task.Dist);
                task.FXMoney.RectTransform.anchoredPosition = Vector2.Lerp(task.FXMoney.RectTransform.anchoredPosition,
                    task.Targets[task.TargetIndex], Time.deltaTime * task.Speed);

                if (Vector2.Distance(task.FXMoney.RectTransform.anchoredPosition, task.Targets[task.TargetIndex]) < 10)
                {
                    task.TargetIndex++;
                    if (task.TargetIndex >= task.Targets.Count)
                    {
                        _tasks.Remove(task);
                        index--;
                        
                        // PlayerSystem.Events.MoneyOnScreenRemove?.Invoke(task.Value);
                        Destroy(task.FXMoney.gameObject);
                        continue;
                    }
                }
            }
        }
        
        private Vector2 GetPositionScreen(Transform worldObject)
        {
            Vector2 ViewportPosition = _camera.WorldToViewportPoint(worldObject.position);
            
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ViewportPosition.x * _canvas.sizeDelta.x - _canvas.sizeDelta.x * 0.5f,
                ViewportPosition.y * _canvas.sizeDelta.y - _canvas.sizeDelta.y * 0.5f);

            return WorldObject_ScreenPosition;
        }

        private Vector2 GetPositionScreenUI(Transform uiObject)
        {
            Vector2 ViewportPosition = _cameraUI.WorldToViewportPoint(uiObject.position);
            
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ViewportPosition.x * _canvas.sizeDelta.x - _canvas.sizeDelta.x * 0.5f,
                ViewportPosition.y * _canvas.sizeDelta.y - _canvas.sizeDelta.y * 0.5f);

            return WorldObject_ScreenPosition;
        }

    }
}

