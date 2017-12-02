using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInput : MonoBehaviour {

    Camera mainCamera;
    int mouseDistance = 1000;
    public GameObject player;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(mouseRay, out hit, mouseDistance);

            

            if (player != null)
            {
                player.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                if (hit.collider.gameObject.tag == "Collectible")
                {
                    player.GetComponent<Collect>().goal = hit.collider.gameObject;
                }
            }

           
        }
	}
}
