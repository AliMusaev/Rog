using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

class PlayerDataController : IMainStats, IExp, IZoneData, IGauge, IInventory, IEquipCells
{
    private MainStatsData mainStats; // 
    private StatsData itemsStats;
    private ExpData expData; 
    private ZoneData zoneData;
    private GaugeData positionData;
    private InventoryData inventoryData; //
    private EquipCellsData equipCellsData; //
    public PlayerDataController()
    {
        mainStats = new MainStatsData();
        expData = new ExpData();
        itemsStats = new StatsData();
        zoneData = new ZoneData();
        positionData = new GaugeData();
        equipCellsData = new EquipCellsData();
        inventoryData = new InventoryData();
        mainStats.Attack = 5;
        mainStats.Defence = 10;
        mainStats.Health = 30;
        mainStats.Points = 1111;
        expData.CurrentExp = 0;
        expData.Level = 1;
        expData.ReqExp = 10;
    }

    public void AddNewItem(ItemData newItem)
    {
        inventoryData.InventoryCollection.Add((ItemData)newItem.Clone());
    }

    public void EquipItem(int cell, ItemData Item)
    {
        equipCellsData.EquipCollection[cell] = (ItemData)Item.Clone();
    }

    public ItemData ExtractOldItemFromCell(int cell)
    {
        return (ItemData)equipCellsData.EquipCollection[cell].Clone();
    }

    public EquipCellsSafetyData GetEquipCells()
    {
        return new EquipCellsSafetyData(equipCellsData.EquipCollection);
    }

    public ExpData GetExpData()
    {
        ExpData retVal = new ExpData();
        retVal.CurrentExp = expData.CurrentExp;
        retVal.ReqExp = expData.ReqExp;
        retVal.Level = expData.Level;
        return retVal;
    }

    public InventorySafetyData GetInventoryData()
    {
        return new InventorySafetyData(inventoryData.InventoryCollection);
    }

    public GaugeData GetLastPosition()
    {
        GaugeData retVal = new GaugeData();
        retVal.Xpos = positionData.Xpos;
        retVal.Zpos = positionData.Zpos;
        retVal.CurrentDist = positionData.CurrentDist;
        return retVal;
    }

    public MainStatsData GetMainStatsData()
    {
        MainStatsData retVal = new MainStatsData();
        retVal.Health = mainStats.Health;
        retVal.Attack = mainStats.Attack;
        retVal.Defence = mainStats.Defence;
        retVal.Points = mainStats.Points;
        return retVal;
    }

    public ZoneData GetZoneData()
    {
        ZoneData retVal = new ZoneData();
        retVal.Level = zoneData.Level;
        retVal.SetpsLeft = zoneData.SetpsLeft;
        retVal.ExpMulti = zoneData.ExpMulti;
        retVal.DropMulti = zoneData.DropMulti;
        retVal.GoldMulti = zoneData.GoldMulti;
        return retVal;
    }

    public void RemoveItem(ItemData removedItem)
    {
        foreach (var item in inventoryData.InventoryCollection)
        {
            if (item.ObjectId == removedItem.ObjectId)
            {
                inventoryData.InventoryCollection.Remove(item);
                break;
            }
        }
        // Sorting inventory by item id
        inventoryData.InventoryCollection.Sort((x, y) => x.ObjectId.CompareTo(y.ObjectId));
    }

    public void RewriteExpData(ExpData input)
    {
        expData.CurrentExp = input.CurrentExp;
        expData.ReqExp = input.ReqExp;
        expData.Level = input.Level;
    }

    public void RewriteMainStatsData(MainStatsData input)
    {
        this.mainStats.Health = input.Health;
        this.mainStats.Attack = input.Attack;
        this.mainStats.Defence = input.Defence;
        this.mainStats.Points = input.Points;
    }

    public void RewriteMainStatsData(int newFP)
    {
        this.mainStats.Points += newFP;
    }

    public void RewritePosition(GaugeData input)
    {
        this.positionData.Xpos = input.Xpos;
        this.positionData.Zpos = input.Zpos;
        this.positionData.CurrentDist = input.CurrentDist;
    }

    public void RewriteZoneData(ZoneData input)
    {
        zoneData.Level = input.Level;
        zoneData.SetpsLeft = input.SetpsLeft;
        zoneData.ExpMulti = input.ExpMulti;
        zoneData.GoldMulti = input.GoldMulti;
        zoneData.DropMulti = input.DropMulti;
    }


}
