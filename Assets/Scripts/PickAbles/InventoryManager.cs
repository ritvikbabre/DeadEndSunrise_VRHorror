using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;
    public List<ItemSO> items = new List<ItemSO>();

    public ItemController[] Inventoryitems;

    

    public Transform ItemContent;
    public GameObject InventoryItem;


    private void Awake()
    {

        Instance = this;
    }

    public void Add(ItemSO item)
    {
        items.Add(item);
    }

    public void Remove(ItemSO item)
    {
        items.Remove(item);
    }

    public void ListItem()
    {
        Inventoryitems = null;
        resetInventoryitems();

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }

        SetInventoryItems();
    }

    public void resetInventoryitems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }


    public void SetInventoryItems()
    {
        
        Inventoryitems = ItemContent.GetComponentsInChildren<ItemController>();

        for (int i = 0; i <items.Count; i++)
        {
            Inventoryitems[i].AddItem(items[i]);
        }

    }
    

}
