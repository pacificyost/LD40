using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD40.Utility;

public class StateControl : MonoBehaviour {
    Animator animator;

    private static States currentState = States.Idle;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public States CurrentState()
    {
        return currentState;
    }

    public void StartMoving()
    {
        animator.SetBool("Moving", true);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", false);
        currentState = States.Moving;
    }

    public void StartCollecting()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", true);
        animator.SetBool("Depositing", false);
        currentState = States.Collecting;
    }

    public void StartDepositing()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", true);
        currentState = States.Depositing;
    }

    public void GoIdle()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Collecting", false);
        animator.SetBool("Depositing", false);
        currentState = States.Idle;
    }
    
}
