using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    [SerializeField] Transform characterTr;

    // �̵� ����
    Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    [SerializeField] float speed = 3f;

    public float Speed { get => speed; set => speed = Mathf.Clamp(value, 0, 10); }

    AnimationHandler animationHandler;

    [SerializeField] private bool isMinigameZone;    // �̴ϰ��� ���� �ִ��� �Ǵ��ϴ� ����
    public bool IsMinigameZone { get => isMinigameZone; set => isMinigameZone = value; }

    UIManager uiManager;

    [SerializeField] GameObject alramUI;            // ��ȣ �ۿ� Ű �˷��ִ� UI ������Ʈ
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        alramUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Look(movementDirection);
        if(IsMinigameZone && Input.GetKeyDown(KeyCode.Space))
        {
            // �̴ϰ��� UI ����
            uiManager.ActiveState();
        }
    }

    private void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Look(Vector2 direction)
    {
        if (direction.magnitude < .5f) return;

        if (direction.x > 0)
            characterTr.rotation = Quaternion.Euler(0, 180, 0);
        else
            characterTr.rotation = Quaternion.identity;
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * Speed;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    private void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            alramUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            alramUI.SetActive(false);
        }
    }
}
