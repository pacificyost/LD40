using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestAI : MonoBehaviour {
    public float spawnDelay = 10.0f;
    public GameObject spawnPrefab;
    public float rechargeDelay = 20.0f;
    public int rechargeAmount = 1;

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
        if (spawnPrefab != null && inventory.quantity > 0)
        {
            GameObject newlySpawned = Instantiate(spawnPrefab, transform.position, Quaternion.identity);
            inventory.quantity--;
        }
    }

    private void Recharge()
    {
        inventory.quantity += rechargeAmount;
    }
}
