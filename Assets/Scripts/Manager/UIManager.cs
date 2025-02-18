using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameState
{
    None,
    Flappy,
    Stack,
    Count
}

public class UIManager : MonoBehaviour
{
    FlappyPlaneStartUI flappyUI;

    private MinigameState minigameState;

    private void Awake()
    {
        flappyUI = GetComponentInChildren<FlappyPlaneStartUI>(true);
        flappyUI.Init(this);
    }

    public void SetMinigameState(MinigameState minigame)
    {
        minigameState = minigame;
    }

    public void ChangeState(MinigameState minigame)
    {
        minigameState = minigame;
        flappyUI.SetActive(minigameState);
    }

    public void ActiveState()
    {
        flappyUI.SetActive(minigameState);
    }
}
