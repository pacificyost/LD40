using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Inventory : MonoBehaviour {

    public int quantity = 0;
    private NavMeshAgent navMeshAgent;
    public float maxSpeed = 10.0f;
    public float encumbranceMultiplier = 1.0f;
    public float minSpeed = 0.5f;

    private void Start()
    {
        if (tag == "Player")
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {
        if (quantity <= 0)
        {
            switch (tag)
            {
                case "Collectible":
                case "Enemy":
                case "Stash":
                    Destroy(this.transform.gameObject);
                    break;
                default:
                    break;
            }
        }
        
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = Mathf.Clamp(maxSpeed - (quantity * encumbranceMultiplier), minSpeed, maxSpeed);
        }
    }

    public void TransferTo(Inventory destination, int amount)
    {
        if (this.quantity > 0)
        {
            if (amount > this.quantity)
            {
                destination.quantity += this.quantity;
                this.quantity = 0;
            }
            else
            {
                this.quantity -= amount;
                destination.quantity += amount;
            }
        }
    }

}
