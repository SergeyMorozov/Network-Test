using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace  GAME
{
    public class BattleUILogic : MonoBehaviour
    {
        private BattleView _view;
        private bool _show;

        private BattleViewSkill _viewSkill;
        private BattleViewSkill _viewSkillInfo;
        private List<BattleViewSkill> _listSkills;

        private BattleData _battle;
        
        private void Awake()
        {
            _view = BattleCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            _view.ButtonExit.onClick.AddListener(BattleExit);
            _viewSkill = InitList(_view.SkillPrefab);
            _viewSkillInfo = InitList(_view.PanelInfo[0].SkillPrefab);
            Tools.RemoveObjects(_view.PanelInfo[1].Content);
            
            _view.PanelBlocking.SetActive(false);
            _view.PanelWait.SetActive(false);
            _view.PanelInfo[0].gameObject.SetActive(false);
            _view.PanelInfo[1].gameObject.SetActive(false);
            
            BattleCanvas.Instance.Show += Show;
            BattleCanvas.Instance.Hide += Hide;
            
            BattleSystem.Events.StateChanged += StateChanged;
        }

        private void StateChanged(BattleData battle, BattleState from, BattleState to)
        {
            if(battle.Players[0] != PlayerSystem.Data.CurrentPlayer) return;

            _battle = battle;
            
            if(to == BattleState.WaitEnemy) Show();
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
            
            _view.PanelWait.SetActive(true);
            _view.IconWait.transform.DOLocalRotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear);
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

        private BattleViewSkill InitList(BattleViewSkill view)
        {
            Transform content = view.transform.parent;
            view.transform.SetParent(content.parent);
            view.gameObject.SetActive(false);
            Tools.RemoveObjects(content);
            return view;
        }
    }
}
