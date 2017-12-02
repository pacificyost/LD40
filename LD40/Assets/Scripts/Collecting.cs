using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour {

    public GameObject goal;
    private Inventory goalInventory;
    public float collectDistance = 3.0f;
    private Inventory inventory;
    

	// Use this for initialization
	void Start () {
        inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {

        if (WithinRange() && PlayerStateControl.CurrentState() != PlayerStateControl.PlayerStates.Collecting)
        {
            PlayerStateControl.StartCollecting();
        }

        if (WithinRange() == false && PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Collecting)
        {
            PlayerStateControl.StopCollecting();
        }

	}

    public void CollectIt()
    {
        
        if (WithinRange() && PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Collecting)
        {
            inventory.collected++;
            goalInventory.collected--;
        }
    }

    private bool WithinRange()
    {
        if (goal != null)
        {
            Vector3 directionToGoal = goal.transform.position - transform.position;

            if (directionToGoal.magnitude < collectDistance)
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
