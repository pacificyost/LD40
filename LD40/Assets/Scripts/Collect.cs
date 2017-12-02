using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    public GameObject goal;
    public float collectDistance = 1.0f;
    Transform self;
    public int collected = 0;

	// Use this for initialization
	void Start () {
        self = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (goal != null)
        {
            Vector3 directionToGoal = goal.transform.position - self.position;

            if (directionToGoal.magnitude < collectDistance)
            {
                CollectIt(goal);

            }
        }
	}

    private void CollectIt(GameObject collectible)
    {
        collected++;
    }
}
