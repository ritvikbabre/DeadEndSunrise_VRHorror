using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="Item/Creat New Item",order =0)]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
    public bool isHealingItem;

    public enum ItemType
    {
        tyre,
        AirFilter,
        fuelCan
    }

}
