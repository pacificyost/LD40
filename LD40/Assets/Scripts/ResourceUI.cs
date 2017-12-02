using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
    Inventory inventory;
    Text resourcesText;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        resourcesText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        resourcesText.text = inventory.quantity.ToString();
        
	}
}
