using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
    public GameObject source;
    Inventory inventory;
    Text resourcesText;
    public string label = string.Empty;

	// Use this for initialization
	void Start () {        
        resourcesText = GetComponent<Text>();
        inventory = source.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inventory != null)
        {
            resourcesText.text = string.Concat(label + ": " + inventory.quantity.ToString());
        }
	}
}
