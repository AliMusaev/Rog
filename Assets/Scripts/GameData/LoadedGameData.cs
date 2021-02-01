using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedGameData
{
    private static readonly LoadedGameData instance = new LoadedGameData();
    public static List<ItemData> ItemsList { get; private set; }
    private LoadedGameData()
    {
        ItemsList = new DataLoader().LoadItemsFromFile();
    }
}
