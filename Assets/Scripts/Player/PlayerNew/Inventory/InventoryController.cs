using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InventoryController :  ICloneable
{
    private List<ItemData> inventoryCollection;
    public ReadOnlyCollection<ItemData> ChoosenItemsCollection { get; private set; }

    public InventoryController()
    {
        inventoryCollection = new List<ItemData>();
    }
    public InventoryController(InventoryController loadedInventory)
    {
        inventoryCollection = new List<ItemData>();
        foreach (var item in loadedInventory.inventoryCollection)
        {
            this.inventoryCollection.Add(item.Clone());
        }
    }
    public void GetItemsListByItemType(int itemType)
    {
        UpdateInventoryCollection(itemType);
    }
    private void UpdateInventoryCollection(int itemType)
    {
        List<ItemData> tempList = new List<ItemData>();
        foreach (var item in inventoryCollection)
        {
            if (item.ItemType == itemType)
            {
                tempList.Add(item.Clone());
            }
        }
        ChoosenItemsCollection = tempList.AsReadOnly();
    }
    public void AddItemInInventory(ItemData newItem)
    {
        inventoryCollection.Add(newItem.Clone());
        SortInventoryList();
    }
    public void RemoveItemFromInventory(ItemData item)
    {
        inventoryCollection.Remove(item);
        SortInventoryList();
    }
    private void SortInventoryList()
    {
        inventoryCollection.Sort((x, y) => x.Id.CompareTo(y.Id));
    } 
    // Update readonly collection for sending in UI
   
    public object Clone()
    {
        return new InventoryController(this);
    }
}
