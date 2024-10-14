using UnityEngine;

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
            GameSystem.Data.GamePause = true;

            _view.InputHostName.text = PlayerPrefs.GetString("host_name", "");
        }

        private void Hide()
        {
            if(!_show) return;
            
            _show = false;
            _view.gameObject.SetActive(false);
            GameSystem.Data.GamePause = false;
        }

        private void MenuHost()
        {
            if(_view.InputHostName.text == "") return;

            string hostName = _view.InputHostName.text;
            HostSystem.Events.StartHost?.Invoke(hostName);
            GameSystem.Events.GameActionWithFade?.Invoke(Hide, GameSystem.Events.GameStart);
        }

        private void MenuClient()
        {
            if(_view.InputHostName.text == "") return;

            string hostName = _view.InputHostName.text;
            ClientSystem.Events.StartClient?.Invoke(hostName);
            GameSystem.Events.GameActionWithFade?.Invoke(Hide, GameSystem.Events.GameStart);
        }
    }
}

