using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    public GameObject goal;
    public float collectDistance = 1.0f;
    private Transform self;
    public int collected = 0;
    public float collectDelay = 10.0f;
    public bool collecting = false;

	// Use this for initialization
	void Start () {
        self = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (WithinRange() && collecting == false)
        {
            Invoke("CollectIt",collectDelay);
            collecting = true;
        }

        if (WithinRange() == false)
        {
            collecting = false;
        }

	}

    private void CollectIt()
    {
        if (WithinRange() && collecting == true)
        {
            collected++;
            collecting = false;
        }
    }

    private bool WithinRange()
    {
        if (goal != null)
        {
            Vector3 directionToGoal = goal.transform.position - self.position;

            if (directionToGoal.magnitude < collectDistance)
            {

                return true;
            }
        }
        return false;
    }
}
