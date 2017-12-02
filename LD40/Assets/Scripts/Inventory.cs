using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public int quantity = 0;


    private void Update()
    {
        if (quantity <= 0)
        {
            switch (tag)
            {
                case "Collectible":
                case "Enemy":
                    Destroy(this.transform.gameObject);
                    break;
                default:
                    break;
            }
        }
           
    }

    public void TransferTo(Inventory destination)
    {
        if (this.quantity > 0)
        {
            this.quantity--;
            destination.quantity++;
        }
    }

}
