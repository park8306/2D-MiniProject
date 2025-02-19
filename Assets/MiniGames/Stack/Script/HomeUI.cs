using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stack
{
    public class HomeUI : BaseUI
    {
        Button startButton;
        Button exitButton;

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }

        public override void Init(UIManager uIManager)
        {
            base.Init(uIManager);

            startButton = transform.Find("StartButton").GetComponent<Button>();

            startButton.onClick.AddListener(OnClickStartButton);
        }

        void OnClickStartButton()
        {
            uiManager.OnClickStart();
        }
    }
}
