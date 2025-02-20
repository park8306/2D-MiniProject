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

    private void SetAspectRatio()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera mainCam = Camera.main;

        if(scaleHeight < 1.0f)
        {
            Rect rect = mainCam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            mainCam.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = mainCam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            mainCam.rect = rect;
        }
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
            // flappy 결과창 출력
            uiManager.ChangeState(MinigameState.FlappyResult);
            uiManager.SetStackResultUI(MinigameManager.Instance.FlappyCurrentScore, MinigameManager.Instance.IsFlappyGoalSuccess);
            MinigameManager.Instance.IsFlappyPlayed = false;
        }
    }
}
