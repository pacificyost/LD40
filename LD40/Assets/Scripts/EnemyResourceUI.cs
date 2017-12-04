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
        
        resourcesText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        int count = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            count += enemy.GetComponent<Inventory>().quantity;
        }
        
        resourcesText.text = string.Concat(label + ": " + count.ToString());

    }
}
