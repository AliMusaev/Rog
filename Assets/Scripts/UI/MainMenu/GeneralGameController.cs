﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGameController : MonoBehaviour
{
    Player player;
    UIController uIController;
    BattleController battleController;
    PlayerDataController playerDataController;

    MainStatsHandler mainStatsHandler;
    ExpHandler expHandler;
    ZoneHandler zoneHandler;
    GaugeController gaugeController;

    private void Start()
    {
        playerDataController = new PlayerDataController();

        expHandler = new ExpHandler(playerDataController);
        mainStatsHandler = new MainStatsHandler(playerDataController);
        zoneHandler = new ZoneHandler(playerDataController);
        gaugeController = new GaugeController(playerDataController);

        uIController = new UIController();

    }

    public void NewGameButtonPressed()
    {
        
        battleController = new BattleController();
        player = new Player(mainStatsHandler, expHandler, zoneHandler, gaugeController);
        OldPlayerMainController.InitializeNewPlayer();
        OldPlayerItemsController.InitializePlayerInventory();
        OldPlayerExpController.InitializeNewExpInfo();
        OldPlayerMainController.UpdatePlayerStats();
    }
}
