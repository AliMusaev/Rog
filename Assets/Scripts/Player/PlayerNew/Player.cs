using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    // Events to UI controller
    public static event Action<MainStatsData> UpdatingMainStats;
    public static event Action<ExpData> UpdatingExpData;
    public static event Action<StepsData> UpdatingStepsData;
    public static event Action<CurrencyData> UpdatingCurrencyData;
    public static event Action<ZoneData> UpdatingZoneData;
    public static event Action<GaugeData> UpdatingBattleGaugeValue;


    private MainStatsHandler mainStatsHandler;
    private ExpHandler expHandler;
    private ZoneHandler zoneHandler;
    private GaugeController gaugeController;
    public Player(MainStatsHandler mainStatsHandler, ExpHandler expHandler, ZoneHandler zoneHandler, GaugeController gaugeController)
    {
        this.mainStatsHandler = mainStatsHandler;
        this.expHandler = expHandler;
        this.zoneHandler = zoneHandler;
        this.gaugeController = gaugeController;
        UIController.SendingNewPlayerStats += RewriteMainStats;
        Zone.SendingZoneData += RewriteZoneData;
        EnemyGauge.SendingNewPosition += UpdateEnemyGauge;
        UpdatingMainStats.Invoke(this.mainStatsHandler.GetData());
        UpdatingExpData.Invoke(this.expHandler.GetData());
        UpdatingExpData.Invoke(this.expHandler.GetData());
    }
    private void UpdateEnemyGauge(float newXpos, float newZpos)
    {
        gaugeController.Update(newXpos, newZpos);
        UpdatingBattleGaugeValue.Invoke(gaugeController.GetGaugeValue());
        if (gaugeController.CheckStatus())
        {
            
        }
        
    }
    private void RewriteZoneData(ZoneData input)
    {
        zoneHandler.RewriteZoneData(input);
        UpdatingZoneData.Invoke(zoneHandler.GetData());
    }
    private void RewriteMainStats(MainStatsData input)
    {
        mainStatsHandler.ReqUpdateMainStats(input);
        UpdatingMainStats.Invoke(mainStatsHandler.GetData());
    }
    private void RewriteMainStats(int input)
    {
        mainStatsHandler.ReqUpdateMainStats(input);
        UpdatingMainStats.Invoke(mainStatsHandler.GetData());
    }
    private void RewriteExpData(int input)
    {
        expHandler.RewriteExpData(input);
        UpdatingExpData.Invoke(expHandler.GetData());
    }






}
