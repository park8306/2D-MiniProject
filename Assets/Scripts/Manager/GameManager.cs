using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    UIManager uiManager;

    [SerializeField] FollowCamera followCamera;

    // 목표 점수, 목표 점수에 따라 실패 성공이 갈림
    private int goalScore = 10;
    public int GoalScore { get { return goalScore; } }

    private float targetAspect = 9f / 16f;

    public float TargetAspect { get => targetAspect; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        CheckMiniGames();

        SetMainResolution();
        //SetAspectRatio();
    }

    public void SetStackResolution()
    {
        Screen.SetResolution(608, 1080, false);
        followCamera.SetCameraRange();
    }

    public void SetMainResolution()
    {
        Screen.SetResolution(1920, 1080, false);
        followCamera.SetCameraRange();
    }

    // 진행한 미니게임이 있는지 체크
    public void CheckMiniGames()
    {
        CheckFlappy();
        CheckStack();
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
    private void CheckStack()
    {
        if (MinigameManager.Instance.IsStackPlayed)
        {
            // stack 결과창 출력
            uiManager.ChangeState(MinigameState.StackResult);
            uiManager.SetStackResultUI(MinigameManager.Instance.StackCurrentScore, MinigameManager.Instance.IsStackGoalSuccess);
            MinigameManager.Instance.IsStackPlayed= false;
        }
    }
}
