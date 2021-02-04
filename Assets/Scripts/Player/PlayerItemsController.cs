using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerItemsController
{
    public static List<ItemData> Inventory { get => _inventory; set => _inventory = value; }
    public static int[] ItemsAddStats { get => _itemsAddStats;}
    public static int[] ItemsStats { get => _itemsMainStats; }

    public static event Action<int> ItemIsEquipped;

    public static Dictionary<int, ItemData> EquippedItems;
    private static List<ItemData> _inventory;
    private static int[] _itemsAddStats;
    private static int[] _itemsMainStats;
    private static int[] _itemsAddStatsMaxValues = new int[11] { 50, 50, 50, 50, 50, 10, 10, 10, 200, 200, 10 };


    public static void InitializePlayerInventory()
    {
        _inventory = new List<ItemData>();
        EquippedItems = new Dictionary<int, ItemData>()
        {
            {0 ,null },{1 ,null },{2 ,null },{3 ,null },{4 ,null },
            {5 ,null },{6 ,null },{7 ,null },{8 ,null },{9 ,null },
            {10 ,null },{11 ,null },{12 ,null },{13 ,null },
        };
        _itemsAddStats = new int[11];
        _itemsMainStats = new int[5];
    }
    public static void EquipItemOnPlayer(ItemData itemData, int chosenItemFieldNumber)
    {
        if (EquippedItems[chosenItemFieldNumber] != null)
            _inventory.Add(EquippedItems[chosenItemFieldNumber]);
        foreach (var item in _inventory)
        {
            if (itemData.Id == item.Id)
            {
                _inventory.Remove(item);
                break;
            }
        }
        EquippedItems[chosenItemFieldNumber] = new ItemData(itemData);
        // Sort inventory after equip item on player.
        SortInventoryList();
        // Call event for update item list (fieldnumber needed for load same item list again)
        ItemIsEquipped.Invoke(chosenItemFieldNumber);
        CalculateItemsAddStats();
        PlayerMainController.UpdatePlayerStats();
    }
    public static void AddNewItemInInventory(ItemData newItem)
    {
        _inventory.Add(newItem);
    }
    // Returns item type binded to item field
    public static int GetItemTypeByCellNumber(int chosenItemFieldNumber)
    {
        switch (chosenItemFieldNumber)
        {
            case 0:
                return 0;
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
            case 4:
                return 4;
            case 5:
                return 5;
            case 6:
                return 6;
            case 7:
                return 7;
            case 8:
                return 7;
            case 9:
                return 8;
            case 10:
                return 8;
            case 11:
                return 9;
            case 12:
                return 10;
            case 13:
                return 11;
            default:
                return -1;
        }
    }
    private static void SortInventoryList()
    { 
        _inventory.Sort((x, y) => x.Id.CompareTo(y.Id));
    }
    private static void CalculateItemsAddStats()
    {
        for (int i = 0; i < _itemsAddStats.Length; i++)
        {
            _itemsAddStats[i] = 0;
        }
        for (int i = 0; i < _itemsMainStats.Length; i++)
        {
            _itemsMainStats[i] = 0;
        }
        
        foreach (var item in EquippedItems)
        {
            // If item is equipped
            if (item.Value != null)
            {   // Get the main stat from equipped item
                _itemsMainStats[item.Value.ItemValueId] += item.Value.ItemValue;
                // Get additional stats from equipped item
                for (int i = 0; i < item.Value.ItemAdditionalsId.Length; i++)
                {
                    // If additional stats is exist
                    if (item.Value.ItemAdditionalsId[i]!= -1)
                    {
                        // Stat overload check
                        if (_itemsAddStats[item.Value.ItemAdditionalsId[i]] + item.Value.ItemAdditionalsValues[i] <= _itemsAddStatsMaxValues[item.Value.ItemAdditionalsId[i]])
                        {
                            _itemsAddStats[item.Value.ItemAdditionalsId[i]] += item.Value.ItemAdditionalsValues[i];
                        }
                        // If stat is overloaded then set max acceptable value
                        else
                        {
                            _itemsAddStats[item.Value.ItemAdditionalsId[i]] = _itemsAddStatsMaxValues[item.Value.ItemAdditionalsId[i]];
                        }
                        
                    }
                }
            }
        }
    }

   
}
