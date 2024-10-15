using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace  GAME
{
    public class BattleUILogicWait : MonoBehaviour
    {
        private BattleView _view;
        private bool _show;

        private BattleData _battle;
        
        private void Awake()
        {
            _view = BattleCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            _view.ButtonExit.onClick.AddListener(BattleExit);
            _view.ButtonCreatePlayer.onClick.AddListener(CreateLocalPlayer);
            
            BattleCanvas.Instance.Show += Show;
            BattleCanvas.Instance.Hide += Hide;
            
            BattleSystem.Events.StateChanged += StateChanged;
        }

        private void StateChanged(BattleData battle, BattleState from, BattleState to)
        {
            if (battle.Players[0] != PlayerSystem.Data.CurrentPlayer) return;

            _battle = battle;

            switch (to)
            {
                case BattleState.WaitEnemy:
                    Show();
                    break;

                case BattleState.Start:
                    _view.PanelWait.DOFade(0, 0.2f).OnComplete(() => { _view.PanelWait.SetActive(false); });
                    break;

                case BattleState.Finish:
                    Hide();
                    break;

            }
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
            
            _view.PanelWait.SetActive(true);
            _view.PanelWait.alpha = 1;
            _view.IconWait.transform.DOLocalRotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear);
            
            _view.ButtonCreatePlayer.SetActive(true);
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;

            _view.gameObject.SetActive(false);
        }

        private void BattleExit()
        {
            BattleSystem.Events.BattleExit?.Invoke(_battle);
        }

        private void CreateLocalPlayer()
        {
            PlayerPreset playerPreset = PlayerSystem.Settings.PlayerClient;
            PlayerObject player = PlayerSystem.Events.CreatePlayer?.Invoke(playerPreset);
            player.Side = 2;
            player.IsReadyForBattle = true;
            _view.ButtonCreatePlayer.SetActive(false);
        }

    }
}
