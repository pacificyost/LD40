using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    private Inventory goalInventory;
    public float interactDistance = 3.0f;
    private Inventory inventory;
    private bool goalIsSource = false;

    // Use this for initialization
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (WithinRange() && PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Idle)
        {
            if (goalIsSource)
            {
                PlayerStateControl.StartCollecting();
            }
            else
            {
                PlayerStateControl.StartDepositing();
            }
        }

        if (PlayerStateControl.CurrentState() != PlayerStateControl.PlayerStates.Idle && WithinRange() == false )
        {
            PlayerStateControl.GoIdle();
        }

    }

    public void Transfer()
    {
        Debug.Log(goalInventory);
        if (WithinRange())
        {
            if (goalIsSource)
            {
                goalInventory.TransferTo(inventory);
            }
            else
            {
                inventory.TransferTo(goalInventory);
            }
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
