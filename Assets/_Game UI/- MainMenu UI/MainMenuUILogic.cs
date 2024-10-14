using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace  GAME
{
    public class MainMenuUILogic : MonoBehaviour
    {
        private MainMenuView _view;
        private bool _show;

        private void Awake()
        {
            _view = MainMenuCanvas.Instance.View;
            _view.gameObject.SetActive(false);

            GameSystem.Events.GameMainMenuShow += Show;
            GameSystem.Events.GameMainMenuHide += Hide;
            
        }

        private void Start()
        {
            _view.LabelVer.text = "build " + Application.version;
        }

        private void Show()
        {
            if (_show)
            {
                Hide();
                return;
            }

            _show = true;

            _view.gameObject.SetActive(true);

            GameSystem.Data.GamePause = true;
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;

            Debug.Log("GameMainMenuHide");
            
            _view.gameObject.SetActive(false);
            GameSystem.Data.GamePause = false;
        }

        private void MenuHost()
        {
            SoundButtonClick();
        }

        private void MenuClient()
        {
            SoundButtonClick();
        }
        
        private void SoundButtonClick()
        {
            SoundSystem.Events.PlaySound?.Invoke(UISystem.Settings.SoundButtonClick);
        }

    }
}

