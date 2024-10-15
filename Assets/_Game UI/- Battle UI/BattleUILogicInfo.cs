using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace  GAME
{
    public class BattleUILogicInfo : MonoBehaviour
    {
        private BattleView _view;
        private bool _show;
        private BattleViewSkill _viewSkillInfo;
        private BattleData _battle;
        
        private void Awake()
        {
            _view = BattleCanvas.Instance.View;
            
            _viewSkillInfo = InitList(_view.PanelInfo[0].SkillPrefab);
            Tools.RemoveObjects(_view.PanelInfo[1].Content);
            
            _view.PanelBlocking.SetActive(false);
            _view.PanelInfo[0].gameObject.SetActive(false);
            _view.PanelInfo[1].gameObject.SetActive(false);
            
            BattleSystem.Events.StateChanged += StateChanged;
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

            for (int i = 0; i < _battle.Players.Count; i++)
            {
                InitPanelInfo(i);
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
        
        private void InitPanelInfo(int index)
        {
            BattleViewInfo view = _view.PanelInfo[index];
            view.gameObject.SetActive(true);
            view.Player = _battle.Players[index];
        }


        private void Update()
        {
            if(!_show) return;
            
            foreach (BattleViewInfo viewInfo in _view.PanelInfo)
            {
                if (viewInfo.Buffs.Count != viewInfo.Player.Buffs.Count)
                {
                    viewInfo.Buffs.Clear();
                    Tools.RemoveObjects(viewInfo.Content);
                    foreach (SkillData buff in viewInfo.Player.Buffs)
                    {
                        BattleViewSkill viewBuff = Tools.AddUI<BattleViewSkill>(_viewSkillInfo, viewInfo.Content);
                        viewBuff.Skill = buff;
                        viewBuff.Icon.sprite = buff.Preset.Icon;
                        viewInfo.Buffs.Add(viewBuff);
                    }
                }

                foreach (BattleViewSkill viewBuff in viewInfo.Buffs)
                {
                    viewBuff.Text.text = viewBuff.Skill.MovesToRemoveBuff > 0
                        ? viewBuff.Skill.MovesToRemoveBuff.ToString()
                        : "";
                }
                
                viewInfo.TextHealth.text = viewInfo.Player.Health.ToString();
                viewInfo.SliderHealth.value = viewInfo.Player.Health / viewInfo.Player.Preset.Health;
            }
        }
    }
}
