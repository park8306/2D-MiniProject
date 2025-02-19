using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Search;
using UnityEngine;

// �̴ϰ��� ������� ������ Ŭ����
public class MinigameManager : MonoBehaviour
{
    UIManager uiManager;

    public static MinigameManager Instance;

    int flappyCurrentScore;    // �ְ�����
    public int FlappyCurrentScore { get => flappyCurrentScore; }
    bool isFlappyGoalSuccess; // ��ǥ �޼��� �ߴ°�? 
    public bool IsFlappyGoalSuccess { get => isFlappyGoalSuccess; }

    bool isFlappyPlayed;      // �̴ϰ����� �÷��� �ߴ°�?
    public bool IsFlappyPlayed { get => isFlappyPlayed; set => isFlappyPlayed = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

    }

    public void SetFlappyData(int flappyCurrentScore, bool isGoalSuccess, bool isPlayed)
    {
        this.flappyCurrentScore = flappyCurrentScore;
        this.isFlappyGoalSuccess = isGoalSuccess;
        this.isFlappyPlayed = isPlayed;
    }
}
