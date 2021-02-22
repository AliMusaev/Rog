using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class EquippedItemsController :  ICloneable
{
    private Dictionary<int, ItemData> collectionOfEquipCells;
    public ReadOnlyDictionary<int, ItemData> EquippedCells { get; private set; }

    public EquippedItemsController()
    {
        collectionOfEquipCells = new Dictionary<int, ItemData>()
        { {0, null},{1, null},{2, null},{3, null},{4, null},{5, null},
        {6, null},{7, null},{8, null},{9, null},{10, null},{11, null},
        {12, null},{13, null}};
    }

    public EquippedItemsController(EquippedItemsController loadedCells)
    {
        this.collectionOfEquipCells = new Dictionary<int, ItemData>();

        foreach (var item in loadedCells.collectionOfEquipCells)
        {
            this.collectionOfEquipCells.Add(item.Key, item.Value.Clone());
        }
    }

    public ItemData EquipNewItem(int cellNumber, ItemData newItem)
    {
        ItemData oldItem = null;
        // If current cell already have item then remove old item
        if (collectionOfEquipCells[cellNumber] != null)
        {
            oldItem = collectionOfEquipCells[cellNumber].Clone();
        }
        else
        {

        }
        // Equip new item
        collectionOfEquipCells[cellNumber] = newItem.Clone();
        // Return old item
        return oldItem;
    }
    public void GetEquippedItems()
    {
        EquippedCells = new ReadOnlyDictionary<int, ItemData>(collectionOfEquipCells);
    }
    public object Clone()
    {
        return new EquippedItemsController(this);
    }
}
