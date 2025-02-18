using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyPlaneStartUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("FlappyPlane");
    }
    public void OnClickExitButton()
    {
        gameObject.SetActive(false);
    }

    protected override MinigameState GetMiniGameState()
    {
        return MinigameState.Flappy;
    }
}
