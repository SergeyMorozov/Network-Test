using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BattleUILogic : MonoBehaviour
    {
        private BattleView _view;
        private bool _show;

        private void Awake()
        {
            _view = BattleCanvas.Instance.View;
            _view.gameObject.SetActive(false);

            BattleCanvas.Instance.Show += Show;
            BattleCanvas.Instance.Hide += Hide;
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

    }
}
