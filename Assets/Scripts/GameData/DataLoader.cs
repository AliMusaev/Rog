using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader
{
    public  List<ItemData> LoadItemsFromFile()
    {
        int _ItemId = 0;
        var _ItemsList = new List<ItemData>();
        var textAsset = Resources.Load("GameData/Items") as TextAsset;
        string[] texts = textAsset.text.Split('|');
        if (texts != null)
        {
            for (int i = 1; i < texts.Length-1; i++)
            {
                string[] temp = texts[i].Split('\t');
                ItemData item = new ItemData(temp, _ItemId);
                _ItemId++;
                if (item.ItemIsExist)
                {
                    _ItemsList.Add(item);
                }
            }      
        }
        return _ItemsList;
    }
    public List<ZoneData> LoadZoneInfoFromFile()
   {
        var zones = new List<ZoneData>();
        var textAsset = Resources.Load("GameData/ZoneInfo") as TextAsset;
        string[] texts = textAsset.text.Split('|');
        if (texts != null)
        {
            for (int i = 1; i < texts.Length - 1; i++)
            {
                string[] temp = texts[i].Split('\t');
                zones.Add(new ZoneData(temp));
            }  
        }
        return zones;
    }
}
