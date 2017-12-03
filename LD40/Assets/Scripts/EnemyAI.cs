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
        stashInventory = GameObject.FindGameObjectWithTag("Stash").GetComponent<Inventory>();
        home = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponent<Interact>().SetGoal(stashInventory.transform.gameObject,true);
    }
	
	// Update is called once per frame
	void Update () {
		if (stashInventory.quantity > 0)
        {
            navMeshAgent.SetDestination(stashInventory.transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(home);
        }
	}
}
