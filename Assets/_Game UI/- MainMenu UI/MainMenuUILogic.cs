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
            _view.ButtonHost.Button.onClick.AddListener(MenuHost);
            _view.ButtonClient.Button.onClick.AddListener(MenuClient);

            MainMenuCanvas.Instance.Show += Show;
            MainMenuCanvas.Instance.Hide += Hide;
            
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
            _view.InputHostName.text = PlayerPrefs.GetString("host_name", "");

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
            if(_view.InputHostName.text == "") return;
            
            PlayerPrefs.SetString("host_name", _view.InputHostName.text);
            SoundButtonClick();
            
            GameSystem.Events.GameActionWithFade?.Invoke(Hide, GameSystem.Events.GameModeHost);
        }

        private void MenuClient()
        {
            if(_view.InputHostName.text == "") return;
            
            PlayerPrefs.SetString("host_name", _view.InputHostName.text);
            SoundButtonClick();

            GameSystem.Events.GameActionWithFade?.Invoke(Hide, GameSystem.Events.GameModeClient);
        }
        
        private void SoundButtonClick()
        {
            SoundSystem.Events.PlaySound?.Invoke(UISystem.Settings.SoundButtonClick);
        }

    }
}

