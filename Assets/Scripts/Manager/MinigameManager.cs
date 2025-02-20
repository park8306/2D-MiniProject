
using UnityEngine;

// �̴ϰ��� ������� ������ Ŭ����
public class MinigameManager : MonoBehaviour
{
    UIManager uiManager;

    public static MinigameManager Instance;

    /// <summary>
    /// Flappy
    /// </summary>

    int flappyCurrentScore;    // ��������
    public int FlappyCurrentScore { get => flappyCurrentScore; }
    bool isFlappyGoalSuccess; // ��ǥ �޼��� �ߴ°�? 
    public bool IsFlappyGoalSuccess { get => isFlappyGoalSuccess; }
    bool isFlappyPlayed;      // �̴ϰ����� �÷��� �ߴ°�?
    public bool IsFlappyPlayed { get => isFlappyPlayed; set => isFlappyPlayed = value; }

    /// <summary>
    /// Stack
    /// </summary>

    int stackCurrentScore;    // ��������
    public int StackCurrentScore { get => stackCurrentScore; }
    bool isStackGoalSuccess; // ��ǥ �޼��� �ߴ°�? 
    public bool IsStackGoalSuccess { get => isStackGoalSuccess; }

    bool isStackPlayed;      // �̴ϰ����� �÷��� �ߴ°�?
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
