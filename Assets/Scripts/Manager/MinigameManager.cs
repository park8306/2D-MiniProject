
using UnityEngine;

// 미니게임 결과들을 저장할 클래스
public class MinigameManager : MonoBehaviour
{
    UIManager uiManager;

    public static MinigameManager Instance;

    /// <summary>
    /// Flappy
    /// </summary>

    int flappyCurrentScore;    // 현재점수
    public int FlappyCurrentScore { get => flappyCurrentScore; }
    bool isFlappyGoalSuccess; // 목표 달성을 했는가? 
    public bool IsFlappyGoalSuccess { get => isFlappyGoalSuccess; }
    bool isFlappyPlayed;      // 미니게임을 플레이 했는가?
    public bool IsFlappyPlayed { get => isFlappyPlayed; set => isFlappyPlayed = value; }

    /// <summary>
    /// Stack
    /// </summary>

    int stackCurrentScore;    // 현재점수
    public int StackCurrentScore { get => stackCurrentScore; }
    bool isStackGoalSuccess; // 목표 달성을 했는가? 
    public bool IsStackGoalSuccess { get => isStackGoalSuccess; }

    bool isStackPlayed;      // 미니게임을 플레이 했는가?
    public bool IsStackPlayed { get => isStackPlayed; set => isStackPlayed = value; }

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
    public void SetStackData(int stackCurrentScore, bool isGoalSuccess, bool isPlayed)
    {
        this.stackCurrentScore = stackCurrentScore;
        this.isStackGoalSuccess = isGoalSuccess;
        this.isStackPlayed = isPlayed;
    }
}
