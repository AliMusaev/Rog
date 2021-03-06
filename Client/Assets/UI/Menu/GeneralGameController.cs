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
    EquipController equipmentController;
    EquipCellsController equipCellsController;
    InventoryController inventoryController;
    private void Start()
    {
        playerDataController = new PlayerDataController();

        expHandler = new ExpHandler(playerDataController);
        mainStatsHandler = new MainStatsHandler(playerDataController);
        zoneHandler = new ZoneHandler(playerDataController);
        gaugeController = new GaugeController(playerDataController);
        equipCellsController = new EquipCellsController(playerDataController);
        inventoryController = new InventoryController(playerDataController);
        equipmentController = new EquipController(equipCellsController, inventoryController);

        uIController = new UIController();

    }

    public void NewGameButtonPressed()
    {
        
        battleController = new BattleController();
        player = new Player(mainStatsHandler, expHandler, zoneHandler, gaugeController, equipmentController);
        OldPlayerMainController.InitializeNewPlayer();
        OldPlayerItemsController.InitializePlayerInventory();
        OldPlayerExpController.InitializeNewExpInfo();
        OldPlayerMainController.UpdatePlayerStats();
    }
}
