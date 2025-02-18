using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int RunState = Animator.StringToHash("RunState");

    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    public void Move(Vector2 obj)
    {
        float value = obj.magnitude > .5f ? 0.5f : 0.0f;

        animator.SetFloat(RunState, value);
    }
}
