using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePortal : MonoBehaviour
{
    PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsMinigameZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsMinigameZone = false;
        }
    }
}
