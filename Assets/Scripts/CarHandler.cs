using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarHandler : MonoBehaviour
{

    public static CarHandler instance;

    [Header("Max Needed")]
    public int maxTyresNeeded;
    public int maxAirFiltersneeded;
    public int maxFuelCansCollected;


    [Header("Current Collected")]
    public int tyresCollected;
    public int airFilterCollected;
    public int fuelCansCollected;


    [Header("Condition Check")]

    public bool allTyresCollected;
    public bool allAirFilterCollected;
    public bool allFuelCanCollected;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTasks()
    {
        if(tyresCollected >= maxTyresNeeded) {
            allTyresCollected = true;   
        }
        if(airFilterCollected >= maxAirFiltersneeded) {
            allAirFilterCollected = true;
        }
       
        if(fuelCansCollected>=maxFuelCansCollected)
        {
            allFuelCanCollected = true;
        }

        Debug.Log("tired to Update tasks");
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if(allAirFilterCollected&&allFuelCanCollected&&allTyresCollected)
        {

            Debug.Log("YOU WON");
            GameManager.Instance.GameWon();
        }
    }

    public bool Repair(ItemSO item)
    {
        if (!CarInterActor.Instance.CanRepairCar) return false;
        switch (item.itemType)
        {
            case ItemSO.ItemType.tyre:
                tyresCollected++;
                
                break;

            case ItemSO.ItemType.AirFilter:
                airFilterCollected++;
               
                break;

            case ItemSO.ItemType.fuelCan:
                fuelCansCollected++;
                
                break;

            default:
                return false;
                break;

        }
        
        UpdateTasks();

        return true;

    }
}
