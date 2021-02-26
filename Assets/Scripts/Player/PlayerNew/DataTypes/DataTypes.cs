using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class MainStatsData
{
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Points { get; set; }
}
public class ExpData
{
    public int CurrentExp { get; set; }
    public int ReqExp { get; set; }
    public int Level { get; set; }
}
public class CurrencyData
{
    public int Gold { get; set; }
}
public class ZoneData
{
    public int Level { get; set; }
    public int ExpMulti { get; set; }
    public int GoldMulti { get; set; }
    public int DropMulti { get; set; }
    public int SetpsLeft { get; set; }
}

public class RewardData
{
    public ItemData Item { get; }
    public int Exp { get; }
    public int Gold { get; }
}
public class GaugeData
{
    public readonly float maxDist = 100f;
    public float Xpos { get; set; }
    public float Zpos { get; set; }
    public float CurrentDist { get; set; }

}
public class StepsData
{
    public int Value { get; set; }
}
public class StatsData
{
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int CritChance { get; set; }
    public int CritRate { get; set; }
    public int DodgeChance { get; set; }
    public int BlockChance { get; set; }
    public int DropChance { get; set; }
    public int GoldMulti { get; set; }
}
public class InventoryData
{
    public List<ItemData> InventoryCollection { get; set; }
    public InventoryData()
    {
        InventoryCollection = new List<ItemData>();
    }
}
public class InventorySafetyData
{
    public ReadOnlyCollection<ItemData> InventoryCollection { get; }
    public InventorySafetyData(List<ItemData> inventoryCollection)
    {
        this.InventoryCollection = new ReadOnlyCollection<ItemData>(inventoryCollection);
    }
}
public class EquipCellsSafetyData
{
    public ReadOnlyDictionary<int , ItemData> EquipCollection { get; }
    public EquipCellsSafetyData(Dictionary<int, ItemData> equipCollection)
    {
        this.EquipCollection = new ReadOnlyDictionary<int, ItemData>(equipCollection);
    }
}
public class EquipCellsData
{
    public Dictionary<int , ItemData> EquipCollection { get; set; }
    public EquipCellsData()
    {
        EquipCollection = new Dictionary<int, ItemData>()
        {
            {0 ,null },{1 ,null },{2 ,null },{3 ,null },{4 ,null },
            {5 ,null },{6 ,null },{7 ,null },{8 ,null },{9 ,null },
            {10 ,null },{11 ,null },{12 ,null },{13 ,null },
        };
    }
}


