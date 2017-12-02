using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStateControl {
    static Animator animator;

    public enum PlayerStates { Idle, Moving, Collecting, Depositing };

    private static PlayerStates currentState = PlayerStates.Idle;



    private static void GetAnimator()
    {
        if (animator == null)
        {
            animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }
    }

    public static PlayerStates CurrentState()
    {
        return currentState;
    }

    public static void StartMoving()
    {
        GetAnimator();
        animator.SetBool("Moving", true);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", false);
        currentState = PlayerStates.Moving;
    }

    public static void StartCollecting()
    {
        GetAnimator();
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", true);
        animator.SetBool("Depositing", false);
        currentState = PlayerStates.Collecting;
    }

    public static void StartDepositing()
    {
        GetAnimator();
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", true);
        currentState = PlayerStates.Depositing;
    }

    public static void GoIdle()
    {
        GetAnimator();
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", false);
        currentState = PlayerStates.Idle;
    }
    
}
