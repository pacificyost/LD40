using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depositing : MonoBehaviour {

    public GameObject goal;
    private Inventory goalInventory;
    public float interactDistance = 3.0f;
    private Inventory inventory;


    // Use this for initialization
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (WithinRange() && PlayerStateControl.CurrentState() != PlayerStateControl.PlayerStates.Depositing)
        {
            PlayerStateControl.StartDepositing();
        }

        if (PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Depositing  && (WithinRange() == false || inventory.collected <= 0))
        {
            PlayerStateControl.StopDepositing();
        }

    }

    public void DepositIt()
    {

        if (WithinRange() && PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Depositing && inventory.collected > 0)
        {
            inventory.collected--;
            goalInventory.collected++;
        }
    }

    private bool WithinRange()
    {
        if (goal != null)
        {
            Vector3 directionToGoal = goal.transform.position - transform.position;

            if (directionToGoal.magnitude < interactDistance)
            {
                
                return true;
            }
            
        }
        return false;
    }

    public void SetGoal(GameObject goalObject)
    {
        goal = goalObject;
        goalInventory = goal.GetComponent<Inventory>();
    }
}
