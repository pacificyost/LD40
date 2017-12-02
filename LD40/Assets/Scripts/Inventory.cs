using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int collected = 0;


    private void Update()
    {
        if (collected <= 0)
        {
            switch (tag)
            {
                case "Collectible":
                    Destroy(this.transform.gameObject);
                    break;
                default:
                    break;
            }
        }
           
    }

}
