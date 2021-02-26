using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BattleMath
{
    private double[] playerStats;
    private IEnemy enemyParams;
    private Zone actualZone;

    public IEnemy EnemyParams { get => enemyParams;}
    public double[] PlayerStats { get => playerStats;}

    public BattleMath()
    {
        actualZone = BattleDataStorage.ActualZone;
        playerStats = (double[])BattleDataStorage.PlayerStats.Clone();
        enemyParams = BattleDataStorage.Enemy;
        BattleDataStorage.EnemyAttacksCounter.Clear();
        BattleDataStorage.PlayerAttacksCounter.Clear();
    }
    public bool Fight()
    {
        while (playerStats[0] > 0 && enemyParams.EnemyHealth > 0)
        {
            
            PlayerAttacking();
            if (enemyParams.EnemyHealth > 0)
                EnemyAttacking();
        }
        if (playerStats[0] > 0)
            return true;
        else
            return false;
    }
    void PlayerAttacking()
    {
        double dmgCalulated = DmgCalculate(playerStats[1], enemyParams.EnemyDefence);
        enemyParams.EnemyHealth = dmgCalulated;
        if (enemyParams.EnemyHealth < 0)
            enemyParams.EnemyHealth = 0;
        BattleDataStorage.PlayerAttacksCounter.Add(dmgCalulated);
    }
    void EnemyAttacking()
    {
        double dmgCalulated = DmgCalculate(enemyParams.EnemyAttack, playerStats[2]);
        playerStats[0] -= dmgCalulated;
        if (playerStats[0] < 0)
            playerStats[0] = 0;
       BattleDataStorage.EnemyAttacksCounter.Add(dmgCalulated);
    }
    double DmgCalculate(double atk, double def)
    {
        if (atk <= def)
            return 0;
        return atk - def;
    }
    
}
