using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemSO item;

    public void PickUP()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);

    }

   /* private void OnMouseDown()
    {
        PickUP();
    }*/ 
}
