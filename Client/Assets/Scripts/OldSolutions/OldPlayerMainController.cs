using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OldPlayerMainController
{
    public static Zone ActualZone { get; set; }
    public static event Action PlayerMoves;
    public static event Action PlayerStatsUpdated;
    public static int[] MainStats { get => _mainStats; }
    public static double[] PlayerStats { get => _playerStats; }
    public static int Steps { get; set; }
    
    // Player stats it is a result of all players attributes like equipped items and main stats
    private static double[] _playerStats;
    // Main stats it is a general players attributes. Upgrades by level up and increase nedeed attribute
    private static int[] _mainStats;
    public static void InitializeNewPlayer()
    {
        //Hp,Ap,Dp,Agi,Luck - started values for new game
        _mainStats = new int[5] { 100, 25, 10, 0, 0 };
        _playerStats = new double[9];
        PlayerStatsUpdated = null;
        Steps = 30;
    }
    public static void SetNewMainStatsByUserInput(int[] values)
    {
        for (int i = 0; i < _mainStats.Length; i++)
        {

                _mainStats[i] = values[i];
            
        }
        UpdatePlayerStats();
    }
    public static void UpdatePlayerStats()
    {
        int[] mainStats = _mainStats;
        // Summary of main player stats and  main items stats
        for (int i = 0; i < mainStats.Length; i++)
        {
            mainStats[i] = OldPlayerItemsController.ItemsStats[i] + MainStats[i];
        }
        // items additional stats preload
        int[] itemsAddStats = OldPlayerItemsController.ItemsAddStats;
        HealthPointsCalculator(mainStats[0], itemsAddStats[0]);
        AttackPointsCalculator(mainStats[1], itemsAddStats[1]);
        DefencePointsCalculator(mainStats[2], itemsAddStats[2]);
        DodgePercentCalculator(mainStats[3], itemsAddStats[3], itemsAddStats[5]);
        BlockPercentCalculator(mainStats[3], itemsAddStats[3], itemsAddStats[6], mainStats[4], itemsAddStats[4]);
        CritPercentCalculator(mainStats[3], itemsAddStats[3], itemsAddStats[7], mainStats[4], itemsAddStats[4]);
        CritRateCalculator(mainStats[3], itemsAddStats[3], itemsAddStats[8]);
        GoldMultiplierCalculator(mainStats[4], itemsAddStats[4], itemsAddStats[9]);
        LootDropChanceCalculator(mainStats[4], itemsAddStats[4], itemsAddStats[10]);
        // if this action have listeners then call event to update information
       if (PlayerStatsUpdated != null)
        {
            PlayerStatsUpdated.Invoke();
        }
        
        
    }
    public static void UpdateSteps(int value)
    {
        Steps-= value;
        PlayerMoves.Invoke();
    }
    private static void HealthPointsCalculator(int mainHp, int itemsHp)
    {
        _playerStats[0] = mainHp + AddBonusCalculator(mainHp, itemsHp);
    }
    private static void AttackPointsCalculator(int mainAp, int itemsAp)
    {
        _playerStats[1] = mainAp + AddBonusCalculator(mainAp, itemsAp);
    }
    private static void DefencePointsCalculator(int mainDp, int itemsDp)
    {
        _playerStats[2] = mainDp + AddBonusCalculator(mainDp, itemsDp);
    }
    private static void DodgePercentCalculator(int mainAgi, int itemsAgi, int itemsAgiPercent)
    {
        _playerStats[3] = (double)((mainAgi + AddBonusCalculator(mainAgi, itemsAgi)) * 0.0004) + itemsAgiPercent;
    }
    private static void BlockPercentCalculator(int mainAgi, int itemsAgi, int itemsBlockPercent, int mainLuck, int itemsLuck )
    {
        _playerStats[4] = (double)(((mainAgi + AddBonusCalculator(mainAgi, itemsAgi)) * 0.0002)+ (double)((mainLuck + AddBonusCalculator(mainLuck, itemsLuck)) * 0.0002)) + itemsBlockPercent;
    }
    private static void CritPercentCalculator(int mainAgi, int itemsAgi, int itemsCritPercent, int mainLuck, int itemsLuck)
    {
        _playerStats[5] = (double)(((mainAgi + AddBonusCalculator(mainAgi, itemsAgi)) * 0.0002) + (double)((mainLuck + AddBonusCalculator(mainLuck, itemsLuck)) * 0.0002)) + itemsCritPercent;
    }
    private static void CritRateCalculator (int mainAgi, int itemsAgi, int itemsCritPercent)
    {
        _playerStats[6] = (double)((mainAgi + AddBonusCalculator(mainAgi, itemsAgi)) * 0.002) + itemsCritPercent;
    }
    private static void GoldMultiplierCalculator(int mainLuck, int itemsLuck, int itemsGoldPercent)
    {
        _playerStats[7] = (double)((mainLuck + AddBonusCalculator(mainLuck, itemsLuck)) * 0.002) + itemsGoldPercent;
    }
    private static void LootDropChanceCalculator(int mainLuck, int itemsLuck, int ItemsLootPercent)
    {
        _playerStats[8] = (double)((mainLuck + AddBonusCalculator(mainLuck, itemsLuck)) * 0.00002) + ItemsLootPercent;
    }
    private static double AddBonusCalculator(int value1, int value2)
    {
        return (double)value1 * (double)value2 / (double)100;
    }



}
