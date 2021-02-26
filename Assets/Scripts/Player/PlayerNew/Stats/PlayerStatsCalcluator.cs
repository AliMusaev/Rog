using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsCalcluator
{
    private EquipCellsSafetyData equipCells;
    private MainStatsData mainStats;
    private StatsData result;


    // Item Eff id: 0-hp; 1-atk; 2-def; 3-block 4-dodge; 5-crit rate; 6-crit chance; 7-gold multi; 8-drop rate; 
    public StatsData CalculateStats(EquipCellsSafetyData equipCells, MainStatsData mainStats)
    {
        this.equipCells = equipCells;
        this.mainStats = mainStats;
        this.result = new StatsData();
        result.Health += mainStats.Health;
        result.Attack += mainStats.Attack;
        result.Defence += mainStats.Defence;

        foreach (var item in equipCells.EquipCollection)
        {
            AddValue(item.Value.MainEffect);
            AddValue(item.Value.SpecialEffects);
        }


        return result;

    }
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
}
