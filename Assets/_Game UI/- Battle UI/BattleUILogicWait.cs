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
            
            _view.PanelVictory.SetActive(false);
            _view.PanelDefeat.SetActive(false);
            
            _view.ButtonExit.onClick.AddListener(BattleExit);
            _view.ButtonExit.gameObject.SetActive(false);
            // _view.ButtonCreatePlayer.onClick.AddListener(CreateLocalPlayer);
            _view.ButtonNext.onClick.AddListener(MoveNext);
            
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
                    _view.PanelVictory.SetActive(false);
                    _view.PanelDefeat.SetActive(false);
                    break;

                case BattleState.Start:
                    _view.PanelWait.DOFade(0, 0.2f).OnComplete(() => { _view.PanelWait.SetActive(false); });
                    _view.ButtonExit.gameObject.SetActive(true);
                    break;

                case BattleState.Finish:
                    int winSide = BattleSystem.Data.CurrentBattle.WinSide;
                    _view.PanelVictory.SetActive(winSide == PlayerSystem.Data.CurrentPlayer.Side);
                    _view.PanelDefeat.SetActive(winSide != PlayerSystem.Data.CurrentPlayer.Side);
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
            
            // _view.ButtonCreatePlayer.SetActive(true);
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;

            _view.gameObject.SetActive(false);
        }

        private void BattleExit()
        {
            NetCommand command = new NetCommand { Name = "BattleClose" };
            NetworkSystem.Events.SendCommand?.Invoke(command);
        }

        private void CreateLocalPlayer()
        {
            PlayerSystem.Events.CreateLocalPlayer?.Invoke();
            
            // _view.ButtonCreatePlayer.SetActive(false);
        }

        private void MoveNext()
        {
            SkillData skill = _battle.Players[1].Skills[3];
            if(skill.IsActive)
            {
                Debug.Log("EnemySkill " + skill.Preset.Name);
                SkillSystem.Events.SkillActive?.Invoke(_battle, _battle.PlayerSource, _battle.PlayerTarget, skill);
            }
            else
            {
                BattleSystem.Events.MoveComplete?.Invoke(_battle);
            }
        }
    }
}
