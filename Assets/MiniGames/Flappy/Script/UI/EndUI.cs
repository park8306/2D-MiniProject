using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Flappy
{
    public class EndUI : BaseUI
    {
        [SerializeField] TextMeshProUGUI highScoreText;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] Button endBtn;
        [SerializeField] GameObject successText;
        [SerializeField] GameObject faileText;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            endBtn.onClick.AddListener(OnClickEnd);
        }
        protected override UIState GetUIState()
        {
            return UIState.End;
        }

        public void OnClickEnd()
        {
            SceneManager.LoadScene("MainScene");
        }

        // 목표에 성공했으면 Success가 실패했으면 Fail이 보이도록 설정
        public void SetGoalText()
        {
            successText.SetActive(GameManager.Instance.CheckGoal());
            faileText.SetActive(!GameManager.Instance.CheckGoal());
        }

        public void SetScoreText()
        {
            highScoreText.text = GameManager.Instance.HighScore.ToString();
            scoreText.text = GameManager.Instance.CurrentScore.ToString();
        }
    }
}
