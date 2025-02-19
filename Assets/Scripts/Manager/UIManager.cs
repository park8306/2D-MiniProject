using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameState
{
    None,
    FlappyStart,
    FlappyResult,
    Stack,
    Count
}

public class UIManager : MonoBehaviour
{
    FlappyPlaneStartUI flappyUI;
    FlappyPlaneResultUI flappyResultUI;

    private MinigameState minigameState;

    private void Awake()
    {
        flappyUI = GetComponentInChildren<FlappyPlaneStartUI>(true);
        flappyUI.Init(this);

        flappyResultUI = GetComponentInChildren<FlappyPlaneResultUI>(true);
        flappyResultUI.Init(this);

        ChangeState(MinigameState.None);
    }

    public void SetMinigameState(MinigameState minigame)
    {
        minigameState = minigame;
    }

    public void ChangeState(MinigameState minigame)
    {
        minigameState = minigame;
        flappyUI.SetActive(minigameState);
        flappyResultUI.SetActive(minigameState);
    }

    public void ActiveState()
    {
        flappyUI.SetActive(minigameState);
    }

    public void SetFlappyResultUI(int flappyCurrentScore, bool isGoalSuccess)
    {
        flappyResultUI.SetScore(flappyCurrentScore, isGoalSuccess);
    }
}
