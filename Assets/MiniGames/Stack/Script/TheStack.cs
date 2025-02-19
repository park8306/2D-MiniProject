using UnityEngine;

namespace Stack
{
    public class TheStack : MonoBehaviour
    {

        private const float BoundSize = 3.5f; // 블럭의 사이즈
        private const float MovingBoundSize = 3f;   // 이동하는 양
        private const float StackMovingSpeed = 5.0f;    // 이동 스피드
        private const float BlockMovingSpeed = 3.5f;
        private const float ErrorMargin = 0.1f;

        public GameObject originBlock = null;

        private Vector3 prevBlockPosition;  // 이전의 블럭 위치
        private Vector3 desiredPosition;    // 이동해야되는 포지션
        private Vector3 stackBounds = new Vector2(BoundSize, BoundSize);    // 생성할 블럭의 사이즈

        Transform lastBlock = null;
        float blockTransition = 0f;
        float secondaryPosition = 0f;

        int stackCount = -1;
        public int Score { get { return stackCount; } }

        int comboCount = 0;
        public int Combo { get { return comboCount; } }

        private int maxCombo = 0;
        public int MaxCombo { get => maxCombo; }

        public Color prevColor;
        public Color nextColor;

        bool isMovingX = true;

        int bestScore = 0;
        public int BestScore { get => bestScore; }

        int bestCombo = 0;
        public int BestCombo { get => bestCombo; }

        private const string BestScoreKey = "BestScore";
        private const string BestComboKey = "BestCombo";

        bool isGameOver = true;

        // Start is called before the first frame update
        void Start()
        {
            if (originBlock == null)
            {
                Debug.Log("OriginBlock is NULL");
                return;
            }

            bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
            bestCombo = PlayerPrefs.GetInt(BestComboKey, 0);

            prevColor = GetRandomColor();
            nextColor = GetRandomColor();

            prevBlockPosition = Vector3.down;

            Spawn_Block();
            Spawn_Block();

        }

        // Update is called once per frame
        void Update()
        {
            if (isGameOver)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                if (PlaceBlock())
                {
                    // 제대로 놓아졌다면
                    Spawn_Block();
                }
                else
                {
                    Debug.Log("Game Over");
                    UpdateScore();
                    isGameOver = true;
                    GameOverEffect();
                    UIManager.Instance.SetScoreUI();
                }
            }

            MoveBlock();
            transform.position = Vector3.Lerp(transform.position, desiredPosition, StackMovingSpeed * Time.deltaTime);
        }

        bool Spawn_Block()
        {
            if (lastBlock != null)
                prevBlockPosition = lastBlock.localPosition;

            GameObject newBlock = null;
            Transform newTrans = null;

            newBlock = Instantiate(originBlock);

            if (newBlock == null)
            {
                Debug.Log("NewBlock Instantiate Failed");
                return false;
            }

            ColorChange(newBlock);

            newTrans = newBlock.transform;
            newTrans.parent = this.transform;
            newTrans.localPosition = prevBlockPosition + Vector3.up;
            newTrans.localRotation = Quaternion.identity;
            newTrans.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

            stackCount++;

            desiredPosition = Vector3.down * stackCount; // 스택 카운트가 증가하는 만큼 theStack을 하나씩 내릴 것임. 쌓은 블록이 중앙에 위치하기 위함
            blockTransition = 0f;

            lastBlock = newTrans;

            isMovingX = !isMovingX;

            UIManager.Instance.UpdateScore();

            return true;
        }

        Color GetRandomColor()
        {
            float r = Random.Range(100f, 250f) / 255f;
            float g = Random.Range(100f, 250f) / 255f;
            float b = Random.Range(100f, 250f) / 255f;

            return new Color(r, g, b);
        }

        void ColorChange(GameObject go)
        {
            Color applyColor = Color.Lerp(prevColor, nextColor, (stackCount % 11) / 10f);

            Renderer rn = go.GetComponent<Renderer>();

            if (rn == null)
            {
                Debug.Log("Renderer is NULL");
            }

            rn.material.color = applyColor;
            Camera.main.backgroundColor = applyColor - new Color(0.1f, 0.1f, 0.1f);

            if (applyColor.Equals(nextColor) == true)
            {
                prevColor = nextColor;
                nextColor = GetRandomColor();
            }
        }

        void MoveBlock()
        {
            blockTransition += Time.deltaTime * BlockMovingSpeed;

            float movePosition = Mathf.PingPong(blockTransition, BoundSize) - BoundSize / 2;
            Debug.Log("MovePosition : " + movePosition);

            if (isMovingX)
            {
                lastBlock.localPosition = new Vector3(movePosition * MovingBoundSize, stackCount, secondaryPosition);
            }
            else
            {
                lastBlock.localPosition = new Vector3(secondaryPosition, stackCount, -movePosition * MovingBoundSize);
            }
        }

        bool PlaceBlock()
        {
            Vector3 lastPosition = lastBlock.localPosition;

            // x축으로 움직일 때
            if (isMovingX)
            {
                // 잘려 나가야되는 크기
                // 마지막에 놓은 블럭과 그 아래의 블럭은 크기가 같음
                // 그러므로 마지막의 놓은 블럭과 그 아래의 블럭의 중심점의 차이만큼 벗어나는 크기가 될것임
                // 예시 *가 중심 점
                // |_____*_____|
                //  (잘림)|_____*_____|
                float deltaX = prevBlockPosition.x - lastPosition.x;
                bool isNegativeNum = (deltaX < 0) ? true : false;   // 파편이 왼쪽으로 떨어져야 하는지 아니면 오른쪽으로 떨어져야하는지 결정하는 변수


                deltaX = Mathf.Abs(deltaX);

                if (deltaX > ErrorMargin)
                {
                    // 생성할 블럭의 크기를 차이만큼 줄임
                    stackBounds.x -= deltaX;
                    // 0보다 작으면 블럭을 잘못 놓은것임 (게임오버)
                    if (stackBounds.x <= 0)
                    {
                        return false;
                    }

                    // 잘린 블럭의 중심점
                    float middle = (prevBlockPosition.x + lastPosition.x) / 2f;

                    lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                    Vector3 tempPosition = lastBlock.localPosition;
                    tempPosition.x = middle;
                    lastBlock.localPosition = lastPosition = tempPosition;

                    float rubbleHalfScale = deltaX / 2f;
                    CreateRubble(
                        new Vector3(
                            isNegativeNum
                            ? lastPosition.x + stackBounds.x / 2 + rubbleHalfScale
                            : lastPosition.x - stackBounds.x / 2 - rubbleHalfScale
                        , lastPosition.y, lastPosition.z),
                        new Vector3(deltaX, 1, stackBounds.y));

                    comboCount = 0;
                }
                else
                {
                    ComboCheck();
                    // 오차 범위가 0.1f 보다 작은 경우 블럭의 잘림 없이 진행
                    lastBlock.localPosition = prevBlockPosition + Vector3.up;
                }
            }
            else
            {
                // 잘려 나가야되는 크기
                // 마지막에 놓은 블럭과 그 아래의 블럭은 크기가 같음
                // 그러므로 마지막의 놓은 블럭과 그 아래의 블럭의 중심점의 차이만큼 벗어나는 크기가 될것임
                // 예시 *가 중심 점
                // |_____*_____|
                //  (잘림)|_____*_____|
                float deltaZ = prevBlockPosition.z - lastPosition.z;

                bool isNegativeNum = (deltaZ < 0) ? true : false;   // 파편이 왼쪽으로 떨어져야 하는지 아니면 오른쪽으로 떨어져야하는지 결정하는 변수

                deltaZ = Mathf.Abs(deltaZ);

                if (deltaZ > ErrorMargin)
                {
                    // 생성할 블럭의 크기를 차이만큼 줄임
                    stackBounds.y -= deltaZ;
                    // 0보다 작으면 블럭을 잘못 놓은것임 (게임오버)
                    if (stackBounds.y <= 0)
                    {
                        return false;
                    }

                    // 잘린 블럭의 중심점
                    float middle = (prevBlockPosition.z + lastPosition.z) / 2f;

                    lastBlock.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);

                    Vector3 tempPosition = lastBlock.localPosition;
                    tempPosition.z = middle;
                    lastBlock.localPosition = lastPosition = tempPosition;

                    float rubbleHalfScale = deltaZ / 2f;
                    CreateRubble(
                        new Vector3(lastPosition.x,
                        lastPosition.y,
                        isNegativeNum
                            ? lastPosition.z + stackBounds.y / 2 + rubbleHalfScale
                            : lastPosition.z - stackBounds.y / 2 - rubbleHalfScale),
                        new Vector3(stackBounds.x, 1, deltaZ));

                    comboCount = 0;
                }
                else
                {
                    ComboCheck();
                    // 오차 범위가 0.1f 보다 작은 경우 블럭의 잘림 없이 진행
                    lastBlock.localPosition = prevBlockPosition + Vector3.up;
                }
            }

            secondaryPosition = (isMovingX) ? lastBlock.localPosition.x : lastBlock.localPosition.z;

            return true;
        }

        void CreateRubble(Vector3 pos, Vector3 scale)
        {
            GameObject go = Instantiate(lastBlock.gameObject);

            go.transform.parent = this.transform;

            go.transform.localPosition = pos;
            go.transform.localScale = scale;
            go.transform.localRotation = Quaternion.identity;

            go.AddComponent<Rigidbody>();
            go.name = "Rubble";
        }

        void ComboCheck()
        {
            comboCount++;

            if (comboCount > maxCombo)
                maxCombo = comboCount;

            if ((comboCount % 5) == 0)
            {
                Debug.Log("5 Combo Success!");
                stackBounds += new Vector3(0.5f, 0.5f);
                stackBounds.x = (stackBounds.x > BoundSize) ? BoundSize : stackBounds.x;
                stackBounds.y = (stackBounds.y > BoundSize) ? BoundSize : stackBounds.y;
            }
        }

        void UpdateScore()
        {
            if (bestScore < stackCount)
            {
                Debug.Log("최고 점수 갱신");
                bestScore = stackCount;
                bestCombo = maxCombo;

                PlayerPrefs.SetInt(BestScoreKey, bestScore);
                PlayerPrefs.SetInt(BestComboKey, bestCombo);
            }
        }

        private void GameOverEffect()
        {
            int childCount = this.transform.childCount;

            for (int i = 1; i < 20; i++)
            {
                if (childCount < i) break;

                GameObject go = transform.GetChild(childCount - i).gameObject;
                if (go.name.Equals("Rubble")) continue;

                Rigidbody rigid = go.AddComponent<Rigidbody>();
                rigid.AddForce((Vector3.up * Random.Range(0, 10f) + Vector3.right * (Random.Range(0, 10f) - 5f)) * 100f);
            }
        }

        public void Restart()
        {
            int childCount = transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            isGameOver = false;

            lastBlock = null;
            desiredPosition = Vector3.zero;
            stackBounds = new Vector3(BoundSize, BoundSize);

            stackCount = -1;
            isMovingX = true;
            blockTransition = 0f;
            secondaryPosition = 0f;

            comboCount = 0;
            maxCombo = 0;

            prevBlockPosition = Vector3.down;

            prevColor = GetRandomColor();
            nextColor = GetRandomColor();

            Spawn_Block();
            Spawn_Block();
        }
    }

}

