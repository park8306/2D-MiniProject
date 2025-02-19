using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Stack
{
    public class GameOverUI : BaseUI
    {
        TextMeshProUGUI scoreText;
        TextMeshProUGUI comboText;
        TextMeshProUGUI bestScoreText;
        TextMeshProUGUI bestComboText;

        [SerializeField] GameObject successText;
        [SerializeField] GameObject failText;

        Button okButton;

        protected override UIState GetUIState()
        {
            return UIState.Score;
        }

        public override void Init(UIManager uIManager)
        {
            base.Init(uIManager);

            scoreText = transform.GetChild(4).Find("ScoreText").GetComponent<TextMeshProUGUI>();
            comboText = transform.GetChild(4).Find("ComboText").GetComponent<TextMeshProUGUI>();
            bestScoreText = transform.GetChild(4).Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            bestComboText = transform.GetChild(4).Find("BestComboText").GetComponent<TextMeshProUGUI>();

            okButton = transform.Find("OkButton").GetComponent<Button>();

            okButton.onClick.AddListener(OnClickExitButton);
        }

        public void SetUI(int score, int combo, int bestScore, int bestCombo, bool isGoal)
        {
            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
            bestScoreText.text = bestScore.ToString();
            bestComboText.text = bestCombo.ToString();

            successText.SetActive(isGoal);
            failText.SetActive(!isGoal);
        }

        void OnClickExitButton()
        {
            uiManager.OnClickExit();
        }
    }
}