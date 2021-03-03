using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsCalcluator
{

    private StatsData result;
    private StatsData maxStats;
    // Item Eff id: 0-hp; 1-atk; 2-def; 3-block 4-dodge; 5-crit rate; 6-crit chance; 7-gold multi; 8-drop rate; 
    public PlayerStatsCalcluator()
    {
        maxStats = new StatsData();
        maxStats.Health = int.MaxValue;
        maxStats.Attack = int.MaxValue;
        maxStats.Defence = int.MaxValue;
        // Values represent percentage : 600/1000 - 60%. - x0.6 multiplier;
        maxStats.BlockChance = 600;
        maxStats.DodgeChance = 600;
        maxStats.CritChance = 800;
        // Crit Rate value = 600% equial x6 multiplier;
        maxStats.CritRate = 600;
        // Values  represent = 500% equial x5 multiplier;
        maxStats.GoldMulti = 500;
        maxStats.DropChance = 500;
    }
    public StatsData CalculateStats(EquipCellsSafetyData equipCells, MainStatsData mainStats)
    {
        this.result = new StatsData();
        result.Health += mainStats.Health;
        result.Attack += mainStats.Attack;
        result.Defence += mainStats.Defence;

        foreach (var item in equipCells.EquipCollection)
        {
            AddValue(item.Value.MainEffect);
            AddValue(item.Value.SpecialEffects);
        }

        CheckValues();
        return result;

    }
    // Need to add IEnumerator in StatsData, MainStats, ItemStats and refactor this
    private void AddValue(int [,] value)
    {
        int rows = value.GetUpperBound(0) + 1;
        int columns = value.Length / rows;

        for (int i = 0; i < columns; i++)
        {
            switch (value[columns,0])
            {
                case 0:
                    result.Health += value[columns, 1];
                    break;
                case 1:
                    result.Attack += value[columns, 1];
                    break;
                case 2:
                    result.Defence += value[columns, 1];
                    break;
                case 3:
                    result.BlockChance += value[columns, 1];
                    break;
                case 4:
                    result.DodgeChance += value[columns, 1];
                    break;
                case 5:
                    result.CritRate += value[columns, 1];
                    break;
                case 6:
                    result.CritChance += value[columns, 1];
                    break;
                case 7:
                    result.GoldMulti += value[columns, 1];
                    break;
                case 8:
                    result.DropChance += value[columns, 1];
                    break;
                default:
                    break;
            }
        }
        
    }

    // Need to add IEnumerator in StatsData, MainStats, ItemStats and refactor this
    private void CheckValues()
    {
        if (result.Health < 0)
            result.Health = maxStats.Health;
        if (result.Attack < 0)
            result.Attack = maxStats.Attack;
        if (result.Defence < 0)
            result.Defence = maxStats.Defence;
        if (result.BlockChance > maxStats.BlockChance)
            result.BlockChance = maxStats.BlockChance;
        if (result.DodgeChance > maxStats.DodgeChance)
            result.DodgeChance = maxStats.DodgeChance;
        if (result.CritChance > maxStats.CritChance)
            result.CritChance = maxStats.CritChance;
        if (result.CritRate > maxStats.CritRate)
            result.CritRate = maxStats.CritRate;
        if (result.GoldMulti > maxStats.GoldMulti)
            result.GoldMulti = maxStats.GoldMulti;
        if (result.DropChance > maxStats.DropChance)
            result.DropChance = maxStats.DropChance;
    }
}
