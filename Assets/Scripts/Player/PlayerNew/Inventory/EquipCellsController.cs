using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EquipCellsController
{
    private IEquipCells dataController;
    

    public EquipCellsController(IEquipCells dataController)
    {
        this.dataController = dataController;
    }
    public void EquipNewItem(int cell, ItemData newItem)
    {
        dataController.EquipItem(cell, newItem);
    }
    public EquipCellsSafetyData GetEquippedItems()
    {
        return dataController.GetEquipCells();
    }
    public ItemData GetOldItem(int cell)
    {
        return dataController.ExtractOldItemFromCell(cell);
    }

}
