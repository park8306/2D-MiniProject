using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappy
{

    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;

        UIManager uiManager;

        public UIManager UIManager { get { return uiManager; } }

        private void Awake()
        {
            gameManager = this;
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            UIManager.UpdateScore(0);
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            uiManager.SetRestart();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log("Score : " + currentScore);

            UIManager.UpdateScore(currentScore);
        }
    }
}
