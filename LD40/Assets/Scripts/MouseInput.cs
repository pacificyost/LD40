using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseInput : MonoBehaviour {

    private Camera mainCamera;
    private int mouseDistance = 1000;
    private GameObject player;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
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
                    player.GetComponent<Interact>().SetGoal(hit.collider.gameObject, true);
                }

                if (hit.collider.gameObject.tag == "Stash")
                {
                    player.GetComponent<Interact>().SetGoal(hit.collider.gameObject, false);
                }
            }

           
        }

        //Debug.Log(PlayerStateControl.CurrentState().ToString());
	}
}
