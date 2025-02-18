using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePortal : MonoBehaviour
{
    PlayerController playerController;
    UIManager uiManager;

    [SerializeField] private MinigameState minigame;     // 포탈이 실행할 미니게임 종류
    public MinigameState Minigame { get { return minigame; } }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsMinigameZone = true;
            uiManager.SetMinigameState(minigame);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsMinigameZone = false;
            uiManager.SetMinigameState(MinigameState.None);
        }
    }
}
