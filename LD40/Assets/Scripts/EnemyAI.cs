using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    Inventory stashInventory;
    Vector3 home;
    NavMeshAgent navMeshAgent;
    // Use this for initialization
    void Start () {
        home = transform.position;
        
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameObject stash = GameObject.FindGameObjectWithTag("Stash");
        
        if (stash != null)
        {
            stashInventory = stash.GetComponent<Inventory>();
            GetComponent<Interact>().SetGoal(stashInventory.transform.gameObject, true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (stashInventory != null && stashInventory.quantity > 0)
        {
            navMeshAgent.SetDestination(stashInventory.transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(home);
        }
	}
}
