using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;

    // 목표 점수, 목표 점수에 따라 실패 성공이 갈림
    private int goalScore = 10;
    public int GoalScore { get { return goalScore; } }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        CheckMiniGames();
    }

    // 진행한 미니게임이 있는지 체크
    public void CheckMiniGames()
    {
        CheckFlappy();
    }

    private void CheckFlappy()
    {
        if (MinigameManager.Instance.IsFlappyPlayed)
        {
            // flappy 결과창 출력
            uiManager.ChangeState(MinigameState.FlappyResult);
            uiManager.SetFlappyResultUI(MinigameManager.Instance.FlappyCurrentScore, MinigameManager.Instance.IsFlappyGoalSuccess);
            MinigameManager.Instance.IsFlappyPlayed = false;
        }
    }
}
