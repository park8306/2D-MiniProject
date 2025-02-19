using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlappyPlaneResultUI : BaseUI
{
    [SerializeField] TextMeshProUGUI flappyScore;
    [SerializeField] TextMeshProUGUI goal;

    [SerializeField] Button OkButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        OkButton.onClick.AddListener(OnClickOkButton);
    }

    public void OnClickOkButton()
    {
        gameObject.SetActive(false);
    }

    protected override MinigameState GetMiniGameState()
    {
        return MinigameState.FlappyResult;
    }

    public void SetScore(int flappyCurrentScore, bool isGoalSuccess)
    {
        flappyScore.text = flappyCurrentScore.ToString();
        goal.text = isGoalSuccess ? "Success!!" : "Fail...";
    }
}
