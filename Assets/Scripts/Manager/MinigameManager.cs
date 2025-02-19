using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Search;
using UnityEngine;

// 미니게임 결과들을 저장할 클래스
public class MinigameManager : MonoBehaviour
{
    UIManager uiManager;

    public static MinigameManager Instance;

    int flappyCurrentScore;    // 최고점수
    public int FlappyCurrentScore { get => flappyCurrentScore; }
    bool isFlappyGoalSuccess; // 목표 달성을 했는가? 
    public bool IsFlappyGoalSuccess { get => isFlappyGoalSuccess; }

    bool isFlappyPlayed;      // 미니게임을 플레이 했는가?
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
