using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInput : MonoBehaviour {

    public Camera mainCamera;
    int mouseDistance = 100;
    public GameObject player;

	// Use this for initialization
	void Start () {
        //mainCamera = Camera.current;
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(mouseRay);
            Physics.Raycast(mouseRay, out hit, mouseDistance);

            if (player != null)
            {
                player.GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
	}
}
