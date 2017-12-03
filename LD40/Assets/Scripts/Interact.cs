using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD40.Utility;

public class Interact : MonoBehaviour {

    private Inventory goalInventory;
    private StateControl stateControl;
    public float interactDistance = 3.0f;
    private Inventory inventory;
    private bool goalIsSource = false;
    private int transferAmount = 1;

    // Use this for initialization
    void Start()
    {
        inventory = GetComponent<Inventory>();
        stateControl = GetComponent<StateControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (WithinRange() && stateControl.CurrentState() == States.Idle)
        {
            if (goalIsSource)
            {
                stateControl.StartCollecting();
            }
            else
            {
                stateControl.StartDepositing();
            }
        }

        if (stateControl.CurrentState() != States.Idle && WithinRange() == false )
        {
            stateControl.GoIdle();
            transferAmount = 1;
        }

    }

    public void Transfer()
    {
        if (WithinRange())
        {
            if (goalIsSource)
            {
                goalInventory.TransferTo(inventory, transferAmount);
            }
            else
            {
                inventory.TransferTo(goalInventory, transferAmount);
            }
            transferAmount += 1;
        }
    }

    public void Transfer(bool thisIsSource)
    {

        
    }

    private bool WithinRange()
    {
        if (goalInventory != null)
        {
            Vector3 directionToGoal = goalInventory.transform.position - transform.position;

            if (directionToGoal.magnitude < interactDistance)
            {

                return true;
            }

        }
        
        return false;
    }

    public void SetGoal(GameObject goal, bool source)
    {
        goalInventory = goal.GetComponent<Inventory>();
        goalIsSource = source;
    }
}
