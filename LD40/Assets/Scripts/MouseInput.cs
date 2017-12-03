using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInput : MonoBehaviour {

    private Camera mainCamera;
    private int mouseDistance = 1000;
    private Interact interact;
    private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        interact = GetComponent<Interact>();
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = GetMouseClick();
            navMeshAgent.SetDestination(hit.point);
            
        }
    }

    private RaycastHit GetMouseClick()
    {
        RaycastHit hit = new RaycastHit();

        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out hit, mouseDistance);

        return hit;
    }
}
