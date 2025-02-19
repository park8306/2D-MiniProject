using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Stack
{
    public class GameUI : BaseUI
    {
        TextMeshProUGUI scoreText;
        TextMeshProUGUI comboText;
        TextMeshProUGUI maxComboText;

        protected override UIState GetUIState()
        {
            return UIState.Game;
        }

        public override void Init(UIManager uIManager)
        {
            base.Init(uIManager);

            scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
            maxComboText = transform.Find("MaxComboText").GetComponent<TextMeshProUGUI>();
        }

        public void SetUI(int score, int combo, int maxCombo)
        {
            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
            maxComboText.text = maxCombo.ToString();
        }
    }
}
