using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestAI : MonoBehaviour {
    public float spawnDelay = 10.0f;
    public GameObject spawnPrefab;
    public float rechargeDelay = 20.0f;
    public int rechargeAmount = 1;
    private GameObject nestOwner;

    Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory = GetComponent<Inventory>();
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
        InvokeRepeating("Recharge",rechargeDelay,rechargeDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Spawn()
    {
        if (nestOwner == null && spawnPrefab != null && inventory.quantity > 0)
        {
            nestOwner = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
            nestOwner.GetComponent<Inventory>().quantity = rechargeAmount;
            inventory.quantity -= rechargeAmount;
        }
    }

    private void Recharge()
    {
        inventory.quantity += rechargeAmount;
        rechargeAmount++;
    }
}
