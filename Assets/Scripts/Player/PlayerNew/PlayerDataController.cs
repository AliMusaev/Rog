﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerDataController : IMainStats, IExp, IZoneData
{
    private MainStatsData mainStats;
    private ItemStatsData itemsStats;
    private ExpData expData;
    private ZoneData zoneData;
    public PlayerDataController()
    {
        mainStats = new MainStatsData();
        expData = new ExpData();
        itemsStats = new ItemStatsData();
        zoneData = new ZoneData();
        mainStats.Attack = 5;
        mainStats.Defence = 10;
        mainStats.Health = 30;
        mainStats.Points = 1111;
        expData.CurrentExp = 0;
        expData.Level = 1;
        expData.ReqExp = 10;
    }

    public ExpData GetExpData()
    {
        ExpData retVal = new ExpData();
        retVal.CurrentExp = expData.CurrentExp;
        retVal.ReqExp = expData.ReqExp;
        retVal.Level = expData.Level;
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

    public void RewriteZoneData(ZoneData input)
    {
        zoneData.Level = input.Level;
        zoneData.SetpsLeft = input.SetpsLeft;
        zoneData.ExpMulti = input.ExpMulti;
        zoneData.GoldMulti = input.GoldMulti;
        zoneData.DropMulti = input.DropMulti;
    }
}