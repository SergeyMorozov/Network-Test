using UnityEngine;

namespace  GAME
{
    public class LoadingUILogic : MonoBehaviour
    {
        private LoadingView _view;
        private bool _show;
        private AppLoadingSystemData _data;
        private Vector2 _offset;
        
        private void Awake()
        {
            _view = LoadingCanvas.Instance.View;
            _data = AppLoadingSystem.Data;
            _offset = new Vector2(-1, 1);
            
            LoadingCanvas.Instance.Show += Show;
            LoadingCanvas.Instance.Hide += Hide;
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
            if (_data.ShowUI && !_show) Show();
            if (!_data.ShowUI && _show) Hide();
            if(!_show) return;

            _view.ProgressBar.value = _data.Value;
            // _view.TextBG.anchoredPosition += _offset;
        }
    }
}

