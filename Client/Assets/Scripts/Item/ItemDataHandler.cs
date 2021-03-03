using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatahandler
{
    private static readonly ItemDatahandler instance = new ItemDatahandler();
    public static List<ItemData> ItemsList { get; private set; }
    private ItemDatahandler()
    {
        ItemsList = new DataLoader().LoadItemsFromFile();
    }
}
