using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;

    // ��ǥ ����, ��ǥ ������ ���� ���� ������ ����
    private int goalScore = 10;
    public int GoalScore { get { return goalScore; } }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        CheckMiniGames();
    }

    // ������ �̴ϰ����� �ִ��� üũ
    public void CheckMiniGames()
    {
        CheckFlappy();
    }

    private void CheckFlappy()
    {
        if (MinigameManager.Instance.IsFlappyPlayed)
        {
            // flappy ���â ���
            uiManager.ChangeState(MinigameState.FlappyResult);
            uiManager.SetFlappyResultUI(MinigameManager.Instance.FlappyCurrentScore, MinigameManager.Instance.IsFlappyGoalSuccess);
            MinigameManager.Instance.IsFlappyPlayed = false;
        }
    }
}
