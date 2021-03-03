using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{

    private StatsMenuHandler statsMenu;
    private HudHandler hud;
    // Send new values into model
    public static event Action<MainStatsData> SendingNewPlayerStats;
    public static event Action RequestingPlayerStats;

    public UIController()
    {
        hud = new HudHandler();
        statsMenu = new StatsMenuHandler();
        StatsMenuHandler.SavingChanges += OnSavingChanges;
        StatsMenuHandler.ResetingValues += OnRequestingPlayerStats;
        Player.UpdatingMainStats += UpdateMainStats;
        Player.UpdatingExpData += UpdateExpData;
        Player.UpdatingZoneData += UpdateZoneData;
        Player.UpdatingBattleGaugeValue += UpdateGaugeValue;
    }

    private void UpdateExpData(ExpData input)
    {
        hud.UpdateExpData(input);
    }
    private void UpdateZoneData(ZoneData input)
    {
        hud.UpdateZoneData(input);
    }
    private void UpdateGaugeValue(GaugeData input)
    {
        hud.UpdateGaugeValue(input);
    }



    // To Model
    private void OnRequestingPlayerStats()
    {
        if (RequestingPlayerStats != null)
        {
            RequestingPlayerStats.Invoke();
        }
    }
    private void OnSavingChanges(MainStatsData newValues)
    {
        SendingNewPlayerStats.Invoke(newValues);
    }
    // To StatsMenu
    private void UpdateMainStats(MainStatsData newValues)
    {
        statsMenu.UpdatePlayerStatsFrom(newValues);
    }
    




    
}
