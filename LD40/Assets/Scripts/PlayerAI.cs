using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {

    float nearbyRange = 3.0f;
    Interact interact;

	// Use this for initialization
	void Start () {
        interact = GetComponent<Interact>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject nearestObject = NearestObject();
        
	}

    private GameObject NearestObject()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, nearbyRange);
        foreach (Collider nearby in nearbyObjects)
        {
            switch (nearby.gameObject.tag)
            {
                case "Collectible":
                    interact.SetGoal(nearby.gameObject, true);
                    break;
                case "Enemy":
                    interact.SetGoal(nearby.gameObject, true);
                    return nearby.gameObject;
                case "Stash":
                    interact.SetGoal(nearby.gameObject, false);
                    break;
                default:
                    break;
            }
        }
        return null;
    }
}
