using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardMath : RewardBaseValues
{
    private Zone actualZone;
    private static System.Random random = new System.Random();
    public int CalculatedExp { get; private set; }
    public int CalculatedGold { get; private set; }
    public double CalculatedLootChance { get; private set; }
    public ItemData item { get; private set; }
    public RewardMath()
    {
        actualZone = BattleDataStorage.ActualZone;
    }
    public void CalculateReward()
    {
        CalculatedExp = (int)(BaseExp*1.1 * actualZone.ZoneLvl * CalculateRewardMiltipliers(1));
        CalculatedGold = (int)(BaseGold * Math.Pow(1.01, actualZone.ZoneLvl) * CalculateRewardMiltipliers(2));
        CalculatedLootChance = (BaseLootChance * CalculateRewardMiltipliers(3));
        CalculateItemGettingChance();
        PlayerExpController.AddExpForBattle(CalculatedExp);
    }
    private int CalculateRewardMiltipliers(int i)
    {
        if (actualZone.ValueType == 0)
        {
            return BaseMultiplier;
        }
        else if (actualZone.ValueType == 1 && i  == 1)
        {
            return BaseMultiplier * actualZone.Value;
        }
        else if (actualZone.ValueType == 2 && i == 2)
        {
            return BaseMultiplier * actualZone.Value;
        }
        else if (actualZone.ValueType == 3 && i == 3)
        {
            return BaseMultiplier * actualZone.Value;
        }
        return BaseMultiplier;
    }

    private void CalculateItemGettingChance()
    {
        if (random.NextDouble() < CalculatedLootChance)
        {
            item = new ItemData(ItemDatahandler.ItemsList[random.Next(0, ItemDatahandler.ItemsList.Count - 1)]);
            PlayerItemsController.AddNewItemInInventory(item);
        }
    }
}
