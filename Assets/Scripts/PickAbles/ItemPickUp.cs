using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemSO item;

    public void PickUP()
    {
        InventoryManager.Instance.Add(item);
        switch (item.itemType) { 
            case ItemSO.ItemType.tyre: GameManager.Instance.numberOfTyresCollected++;
                break;
            case ItemSO.ItemType.fuelCan: GameManager.Instance.numberOfFuelCanCollected++;
                break;
        }
        Destroy(gameObject);

    }

   
}
