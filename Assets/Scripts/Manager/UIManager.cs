using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameState
{
    None,
    FlappyStart,
    FlappyResult,
    StackStart,
    StackResult,
    Count
}

public class UIManager : MonoBehaviour
{
    FlappyPlaneStartUI flappyUI;
    FlappyPlaneResultUI flappyResultUI;

    //StackStartUI stackStartUI;
    //StackResultUI stackResultUI;

    private MinigameState minigameState;

    private void Awake()
    {
        flappyUI = GetComponentInChildren<FlappyPlaneStartUI>(true);
        flappyUI.Init(this);

        flappyResultUI = GetComponentInChildren<FlappyPlaneResultUI>(true);
        flappyResultUI.Init(this);

        //stackStartUI = GetComponentInChildren<StackStartUI>(true);
        //stackStartUI.Init(this);

        //stackResultUI = GetComponentInChildren<StackResultUI>(true);
        //stackResultUI.Init(this);

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

    public void SetFlappyResultUI(int flappyCurrentScore, bool isGoalSuccess)
    {
        flappyResultUI.SetScore(flappyCurrentScore, isGoalSuccess);
    }
}
