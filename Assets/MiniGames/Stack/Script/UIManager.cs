using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stack
{
    public enum UIState
    {
        Home,
        Game,
        Score,
    }

    public class UIManager : MonoBehaviour
    {
        static UIManager instance;

        public static UIManager Instance
        {
            get { return instance; }
        }

        UIState currentState = UIState.Home;
        HomeUI homeUI = null;
        GameUI gameUI = null;
        GameOverUI gameOverUI = null;

        TheStack theStack = null;

        private void Awake()
        {
            instance = this;

            theStack = FindObjectOfType<TheStack>();

            homeUI = GetComponentInChildren<HomeUI>(true);  // 여기서 true는 꺼져있는 오브젝트도 찾을거냐는 의미
            homeUI?.Init(this);

            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI?.Init(this);

            gameOverUI = GetComponentInChildren<GameOverUI>(true);
            gameOverUI?.Init(this);

            ChangeState(UIState.Home);
        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            homeUI?.SetActive(currentState);
            gameUI?.SetActive(currentState);
            gameOverUI?.SetActive(currentState);
        }

        public void OnClickStart()
        {
            theStack.Restart();
            ChangeState(UIState.Game);
        }

        public void OnClickExit()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void UpdateScore()
        {
            gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
        }

        public void SetScoreUI()
        {
            bool isGoal = theStack.Score >= theStack.GoalScore;
            gameOverUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo, isGoal);
            ChangeState(UIState.Score);
        }
    }
}
