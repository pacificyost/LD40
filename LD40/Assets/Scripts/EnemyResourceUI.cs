using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyResourceUI : MonoBehaviour {

    List<Inventory> enemyInventory;
    Text resourcesText;
    public string label = string.Empty;

    // Use this for initialization
    void Start () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyInventory = new List<Inventory>();
        foreach (GameObject enemy in enemies)
        {
            enemyInventory.Add(enemy.GetComponent<Inventory>());
        }
        resourcesText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        int count = 0;
		foreach (Inventory inventory in enemyInventory)
        {
            count += inventory.quantity;
        }
        resourcesText.text = string.Concat(label + ": " + count.ToString());

    }
}
