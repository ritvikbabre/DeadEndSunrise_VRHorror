using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    private bool inventoryEnabled;

    private int allSlots;
    private int enabeledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    void start()
    {
        allSlots = 11;
        slot = new GameObject[allSlots];

        for(int i = 0; i <  allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
