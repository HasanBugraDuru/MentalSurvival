using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private readonly int moving = Animator.StringToHash("Moving");
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");

    private void Awake()
    {
        animator = GetComponent<Animator>();
       
    }

    public void ShowDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    public void SetMoveBooltransaitoin(bool value)
    {
        animator.SetBool(moving, value);    
    }
    public void ResetPlayer()
    {
        SetMoveAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }
    public void SetMoveAnimation(Vector2 dir) 
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }
    public void TriggerAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }
}
