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

public class StepsData
{
    public int Value { get; set; }
}
public class ItemStatsData
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
    public ReadOnlyCollection<ItemData> InventoryCollection { get; set; }
}
public class EquippedItemsData
{
    public ReadOnlyDictionary<int , ItemData> EquipCollection { get; set; }
}


