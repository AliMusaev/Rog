using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController
{
    EquippedItemsController equippedItemsController;
    InventoryController inventoryController;
    public EquipmentController()
    {
        equippedItemsController = new EquippedItemsController();
        inventoryController = new InventoryController();
    }

    // This method work like a swap, - equipped item back to inventory from player, and new item equip on player from inventory.
    public void EquipNewItem(int cellNumber, ItemData newItem)
    {
        // Get old item from player and equip new
        var oldItem = equippedItemsController.EquipNewItem(cellNumber, newItem);

        if (oldItem != null)
        {
            // Add to inventory clone of that item because it has been deleted from equipped items collection
            inventoryController.AddItemInInventory(oldItem);
        }
        else
        {

        }
        // Remove an equipped item from inventory because a clone of that item has been added to the equipped items collection.
        inventoryController.RemoveItemFromInventory(newItem);

    }
    public void GetItemListByType(int itemType)
    {
    }
    public void GetEquippedItems()
    {
    }
    public void AddNewItemToInventory(ItemData newItem)
    {
        inventoryController.AddItemInInventory(newItem);
    }
   
}
    