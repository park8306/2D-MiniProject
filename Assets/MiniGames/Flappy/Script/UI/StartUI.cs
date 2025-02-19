using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy
{
    public class StartUI : BaseUI
    {
        [SerializeField] Button startBtn;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            startBtn.onClick.AddListener(OnClickStart);
        }

        protected override UIState GetUIState()
        {
            return UIState.Start;
        }

        public void OnClickStart()
        {
            GameManager.Instance.StartGame();
        }
    }
}
