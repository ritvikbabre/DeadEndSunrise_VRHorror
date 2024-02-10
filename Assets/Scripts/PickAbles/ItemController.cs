using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public ItemSO itemSO;
    private FirstPersonController player;

    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(itemSO);
        Destroy(gameObject);
    }

    public void AddItem( ItemSO itemSO)
    {
        this.itemSO = itemSO;
    }


    public void UseItem()
    {
        if (itemSO.isHealingItem)
        {
            player.Heal();
            return;
        }
        else
        {
            if (CarHandler.instance.Repair(itemSO)){ RemoveItem(); }
        }

        


    }
}
