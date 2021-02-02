using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HUDDataHandler
{
    public static event Action<int, string> UpdateZoneInfoInHUD;
    private static string ZoneInfoText;
    public static void UpdataZoneInf(Zone _zoneInformation)
    {
        InterpretationZoneInfo(_zoneInformation);
        if (UpdateZoneInfoInHUD != null)
        {
            UpdateZoneInfoInHUD.Invoke(_zoneInformation.ZoneLvl, ZoneInfoText);
        }
        
    }
    private static void InterpretationZoneInfo(Zone zoneInformation)
    {
        switch (zoneInformation.ValueType)
        {
            case 0:
                ZoneInfoText = "Without bonus";
                break;
            case 1:
                ZoneInfoText = $"Exp bonus = {zoneInformation.Value * 100}%, on {zoneInformation.StepCounter} steps";
                break;
            case 2:
                ZoneInfoText = $"Gold bonus = {zoneInformation.Value * 100}%, on {zoneInformation.StepCounter} steps";
                break;
            case 3:
                ZoneInfoText = $"Loot drop bonus = {zoneInformation.Value * 100}%, on {zoneInformation.StepCounter} steps";
                break;
        }
    }
}
