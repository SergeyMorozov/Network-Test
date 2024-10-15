using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace  GAME
{
    public class BattleUILogicUpdate : MonoBehaviour
    {
        private BattleView _view;
        private bool _show;

        private BattleViewSkill _viewSkill;
        private List<BattleViewSkill> _listSkills;

        private BattleData _battle;
        
        private void Awake()
        {
            _view = BattleCanvas.Instance.View;
            
            _viewSkill = InitList(_view.SkillPrefab);
            _listSkills = new List<BattleViewSkill>();
            _view.Content.SetActive(false);
            _view.PanelBlocking.SetActive(false);
            
            BattleSystem.Events.StateChanged += StateChanged;
            BattleSystem.Events.MoveComplete += MoveComplete;
            BattleSystem.Events.MoveReady += MoveReady;
        }

        private void StateChanged(BattleData battle, BattleState from, BattleState to)
        {
            if(battle.Players[0] != PlayerSystem.Data.CurrentPlayer) return;

            _battle = battle;
            
            switch (to)
            {
                case BattleState.Start:
                    Show();
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

            _view.Content.SetActive(true);
            Tools.RemoveObjects(_view.Content);
            foreach (SkillData skill in PlayerSystem.Data.CurrentPlayer.Skills)
            {
                BattleViewSkill viewSkill = Tools.AddUI<BattleViewSkill>(_viewSkill, _view.Content);
                viewSkill.Skill = skill;
                viewSkill.Icon.sprite = skill.Preset.Icon;
                viewSkill.Progress.fillAmount = 0;
                viewSkill.Button.onClick.AddListener(delegate { SelectSkill(skill); });
                _listSkills.Add(viewSkill);
            }
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;

        }

        private BattleViewSkill InitList(BattleViewSkill view)
        {
            Transform content = view.transform.parent;
            view.transform.SetParent(content.parent);
            view.gameObject.SetActive(false);
            Tools.RemoveObjects(content);
            return view;
        }
        
        private void SelectSkill(SkillData skill)
        {
            Debug.Log("SelectSkill " + skill.Preset.Name);
            SkillSystem.Events.SkillActive?.Invoke(_battle, _battle.PlayerSource, _battle.PlayerTarget, skill);
        }
        
        private void MoveComplete(BattleData battle)
        {
            if(_battle.MoveSide == _battle.Players[0].Side) _view.PanelBlocking.SetActive(true);
        }

        private void MoveReady(BattleData battle)
        {
            if(_battle.MoveSide == _battle.Players[0].Side) _view.PanelBlocking.SetActive(false);
        }

        private void Update()
        {
            if(!_show) return;

            foreach (BattleViewSkill viewSkill in _listSkills)
            {
                viewSkill.Button.interactable = viewSkill.Skill.IsActive;
                viewSkill.Text.text = viewSkill.Skill.MovesToRecovery > 0
                    ? viewSkill.Skill.MovesToRecovery.ToString()
                    : ""; 
                
                if(viewSkill.Skill.Preset.TimeRestore == 0) continue;
                viewSkill.Progress.fillAmount = Mathf.Lerp(viewSkill.Progress.fillAmount,
                    viewSkill.Skill.MovesToRecovery / (float)viewSkill.Skill.Preset.TimeRestore, Time.deltaTime * 5);
            }
        }
    }
}
