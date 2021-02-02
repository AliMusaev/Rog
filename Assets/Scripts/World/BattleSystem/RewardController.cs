using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardController
{
    private readonly int baseExp = 50;
    private readonly int baseGold = 5;
    private readonly double baseLootChance = 0.01f;
    private  int exp = 50;
    private  int gold = 5;
    private  double lootChance = 0.01f;
    private double[] _rewardMultipliers;
    private int _zoneLvl;
    public RewardController(int _zoneLvl, double[] _rewardMultipliers)
    {
        this._rewardMultipliers = _rewardMultipliers;
        this._zoneLvl = _zoneLvl;
    }
    public void GetReward()
    {
        CalcReward();
        CalcLootDrop();
        PlayerExpController.AddExpForBattle(exp);
    }
    private void CalcReward()
    {
        exp = (int)(baseExp * 1.1 * _zoneLvl * _rewardMultipliers[0]);
        gold = (int)(baseGold * Math.Pow(1.01, _zoneLvl) * _rewardMultipliers[1]); 
        lootChance = (baseLootChance * _rewardMultipliers[2]);
    }
    private void CalcLootDrop()
    {
        System.Random rand = new System.Random();
        if (rand.NextDouble() < lootChance)
        {
            PlayerItemsController.AddNewItemInInventory(_zoneLvl);
        }
    }
}   

