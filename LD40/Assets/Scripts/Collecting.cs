using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour {

    public GameObject goal;
    public float collectDistance = 2.0f;
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

        if (WithinRange() == false)
        {
            PlayerStateControl.StopCollecting();
        }

	}

    public void CollectIt()
    {
        
        if (WithinRange() && PlayerStateControl.CurrentState() == PlayerStateControl.PlayerStates.Collecting)
        {
            inventory.collected++;
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
}
