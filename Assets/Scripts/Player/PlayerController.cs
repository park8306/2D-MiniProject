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

    // 이동 방향
    Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    [SerializeField] float speed = 3f;

    public float Speed { get => speed; set => speed = Mathf.Clamp(value, 0, 10); }

    AnimationHandler animationHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look(movementDirection);
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
}
