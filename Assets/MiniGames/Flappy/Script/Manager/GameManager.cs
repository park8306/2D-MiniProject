using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappy
{

    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;
        public int CurrentScore { get => currentScore; }
        private int highScore = 0;
        public int HighScore { get => highScore; }

        UIManager uiManager;

        public UIManager UIManager { get { return uiManager; } }

        // 목표 점수, 목표 점수에 따라 실패 성공이 갈림
        private int goalScore = 10;
        public int GoalScore { get { return goalScore; } }

        const string FlappyHighScoreKey = "FlappyHighScore";
        const string FlappyGoalKey = "FlappyHighScore";

        private void Awake()
        {
            ReadyGame();
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();
            LoadScoreData();
        }

        private void Start()
        {
            UIManager.UpdateScore(0);
        }

        // 저장된 점수를 불러옴
        public void LoadScoreData()
        {
            highScore = PlayerPrefs.GetInt(FlappyHighScoreKey);
            uiManager.SetHighScore(highScore);
        }

        // 게임 시작 시 타임 스케일을 원래대로 돌려놓자
        public void StartGame()
        {
            Time.timeScale = 1;
            uiManager.ChangeState(UIState.Game);
        }
        
        // 게임 시작 전 타임스케일을 0으로 만들자
        public void ReadyGame()
        {
            Time.timeScale = 0;
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            uiManager.SetGameOver();

            if (currentScore > highScore)
                highScore = currentScore;

            SaveData();
        }

        public void SaveData()
        {
            bool isGoalSuccess = currentScore >= goalScore;
            MinigameManager.Instance.SetFlappyData(currentScore, isGoalSuccess, true);
        }

        public bool CheckGoal()
        {
            return currentScore >= goalScore;
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log("Score : " + currentScore);

            UIManager.UpdateScore(currentScore);
        }
    }
}
