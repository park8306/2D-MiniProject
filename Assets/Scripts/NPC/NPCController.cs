using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] string npcTale;  // npc가 말할 내용

    [SerializeField] TextMeshProUGUI npcTalkUIText;

    UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsNPCZone = true;
            npcTalkUIText.text = npcTale;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController == null) return;

            playerController.IsNPCZone = false;
            npcTalkUIText.text = "";
            uiManager.ActiveNPCTalk(false);
        }
    }
}
