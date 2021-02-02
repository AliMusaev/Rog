using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone
{
    public int ZoneLvl { get; private set; }
    public int ValueType { get; private set; }
    public int Value { get; private set; }
    public int StepCounter { get; private set; }
    private ZoneDataHandler zoneDataHandler;
    public Zone(int zoneLvl)
    {
        this.ZoneLvl = zoneLvl;
        zoneDataHandler = new ZoneDataHandler();
        UpdateZoneValues(zoneDataHandler.GetNewZone());
        HUDDataHandler.UpdataZoneInf(this);
        PlayerMainController.PlayerMoves += CounterCheck;
    }
    private void CounterCheck()
    {
        StepCounter--;
        if (StepCounter <= 0)
        {
            UpdateZoneValues(zoneDataHandler.GetNewZone());
        }
    }
    private void UpdateZoneValues(int [] newValues)
    {
        this.ValueType = newValues[0];
        this.Value = newValues[1];
        this.StepCounter = newValues[2];
    }
}
