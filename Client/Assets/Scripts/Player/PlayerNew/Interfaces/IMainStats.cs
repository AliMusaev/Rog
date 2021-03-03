using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public interface IMainStats
{
    MainStatsData GetMainStatsData();
    void RewriteMainStatsData(MainStatsData newData);
    void RewriteMainStatsData(int newFP);
}
public interface IExp
{
    ExpData GetExpData();
    void RewriteExpData(ExpData newData);
}
public interface IInventory
{
    InventorySafetyData GetInventoryData();
    void AddNewItem(ItemData newItem);
    void RemoveItem(ItemData removedItem);
}
public interface IEquipCells
{
    EquipCellsSafetyData GetEquipCells();
    void EquipItem(int cell, ItemData Item);
    ItemData ExtractOldItemFromCell(int cell);
}
public interface ISteps
{
    StepsData GetSteps();
    void RewriteSteps(StepsData newData);
}
public interface IZoneData
{
    ZoneData GetZoneData();
    void RewriteZoneData(ZoneData input);
}
public interface IGauge
{
    GaugeData GetLastPosition();
    void RewritePosition(GaugeData input);
}