using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EquipController
{
    EquipCellsController cellsController;
    InventoryController inventoryController;
    public EquipController(EquipCellsController cellsController, InventoryController inventoryController)
    {
        this.cellsController = cellsController;
        this.inventoryController = inventoryController;
    }

    // This method work like a swap, - equipped item back to inventory from player, and new item equip on player from inventory.
    public void EquipNewItem(int cell, ItemData newItem)
    {
        // Get old item from player and equip new
        ItemData oldItem = cellsController.GetOldItem(cell);
        if (oldItem != null)
        {
            // Add to inventory old item because it will be delete from equipped items collection
            inventoryController.AddItemInInventory(oldItem);
        }
        else
        {

        }
        // Removing an item from inventory because it will be add to the equipped items collection.
        inventoryController.RemoveItemFromInventory(newItem);
        // Place new item in choosen cell
        cellsController.EquipNewItem(cell, newItem);

    }
    public InventorySafetyData GetItemListByType(int itemType)
    {
        return inventoryController.GetItemsListByItemType(itemType);
    }
    public EquipCellsSafetyData GetEquippedItems()
    {
        return cellsController.GetEquippedItems();
    }
    public void AddNewItemToInventory(ItemData newItem)
    {
        inventoryController.AddItemInInventory(newItem);
    }
   
}
    