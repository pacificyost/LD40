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
