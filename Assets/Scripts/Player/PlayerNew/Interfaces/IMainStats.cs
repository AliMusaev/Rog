using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMainStats
{
    MainStatsData GetMainStatsData();
    void RewriteMainStatsData(MainStatsData newData);
}
public interface IExp
{
    ExpData GetExpData();
    void RewriteExpData(ExpData newData);
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