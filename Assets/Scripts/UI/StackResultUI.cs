using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackResultUI : BaseUI
{
    [SerializeField] TextMeshProUGUI stackScore;
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
        return MinigameState.StackResult;
    }

    public void SetScore(int stackCurrentScore, bool isGoalSuccess)
    {
        stackScore.text = stackCurrentScore.ToString();
        goal.text = isGoalSuccess ? "Success!!" : "Fail...";
    }
}
