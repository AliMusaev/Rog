using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InventoryController
{
    IInventory dataController;
    

    public InventoryController(IInventory dataController)
    {
        this.dataController = dataController;
    }
    public InventorySafetyData GetItemsListByItemType(int itemType)
    {
        List<ItemData> temp = new List<ItemData>();
        foreach (var item in dataController.GetInventoryData().InventoryCollection)
        {
            if (item.ItemType == itemType)
            {
                temp.Add((ItemData)item.Clone());
            }
        }
        return new InventorySafetyData(temp);  
    }
    public void AddItemInInventory(ItemData newItem)
    {
        dataController.AddNewItem(newItem);
    }
    public void RemoveItemFromInventory(ItemData item)
    {
        dataController.RemoveItem(item);
    }
    public InventorySafetyData GetInventoryCollection()
    {
        return dataController.GetInventoryData();
    }
 
   
  
}
