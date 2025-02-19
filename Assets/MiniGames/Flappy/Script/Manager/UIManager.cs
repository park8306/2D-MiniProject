using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;


namespace Flappy
{
    public enum UIState
    {
        Start,
        Game,
        End,
    }

    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI scoreText;

        StartUI startUI;
        EndUI endUI;
        UIState currentState;

        private void Awake()
        {
            startUI = GetComponentInChildren<StartUI>(true);
            startUI.Init(this);

            endUI = GetComponentInChildren<EndUI>(true);
            endUI.Init(this);

            ChangeState(UIState.Start);
        }

        // Start is called before the first frame update
        void Start()
        {
            if (highScoreText == null)
                Debug.Log("highscore text is null");

            if (scoreText == null)
                Debug.Log("score text is null");
        }
        public void SetGameStart()
        {
            ChangeState(UIState.Start);
        }

        public void SetGameOver()
        {
            ChangeState(UIState.End);
            endUI.SetGoalText();
            endUI.SetScoreText();
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
        public void SetHighScore(int score)
        {
            highScoreText.text = score.ToString();
        }

        public void ChangeState(UIState state)
        {
            currentState = state;

            startUI.SetActive(currentState);
            endUI.SetActive(currentState);
        }
    }
}
