using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController
{
    public static event Action<int> GettingNewExp;

    private static System.Random rand;
    // This equal 100% 
    private readonly int maxRandValue = 1000;
    private RewardData lastReward;
    private StatsData playerStats;
    private IEnemy enemy;
    private ZoneData zoneData;
    public BattleController()
    {
        rand = new System.Random();
    }
    public RewardData StartBattle(ZoneData zoneData, StatsData playerStats)
    {
        this.playerStats = playerStats;
        this.zoneData = zoneData;

        enemy = GenerateNewEnemy(zoneData);


        bool battleResult = Battle();
        if (battleResult)
        {
            lastReward = GenerateReward();
        }
        else
        {
            lastReward = null;
        }
        return lastReward;
    }

    // Return new enemy HP
    private int PlayerAttack()
    {
        int eHpLeft = (int)enemy.Health;
        // player damage with all modificates
        int pDmg = playerStats.Attack;

        if (rand.Next(1, maxRandValue) < playerStats.CritChance)
        {
            // pCritRate max 600% and max value = 600 then 600/100 and pDmg*6 = x6 multi => 600%
            // Convert to double because need to save crit rate, after calculation convert to int
            pDmg = (int)((double)pDmg * ((double)playerStats.CritRate / 100));
        }
        else
        {
        }
        // Reduce damage by armor
        pDmg = pDmg - (int)enemy.Defence;
        // Hit enemy
        if (eHpLeft - pDmg > 0)
        {
            // Reduce enemy hp
            eHpLeft -= pDmg;
        }
        else
            // enemy hp is 0
            eHpLeft = 0;

        return eHpLeft;

    }
    // Return new player HP
    private int EnemyAttack()
    {
        int pHpLeft = playerStats.Health;
        int eDmg = (int)enemy.Attack;
        // If player block is proc
        if (rand.Next(1, maxRandValue) < playerStats.BlockChance)
        {
            return pHpLeft;
        }
        // If player dodge is proc
        else if (rand.Next(1, maxRandValue) < playerStats.DodgeChance)
        {
            return pHpLeft;
        }
        else
        {
            // Enemy hit on player
            eDmg = eDmg - playerStats.Defence;
            pHpLeft -= eDmg;
        }

        return pHpLeft;
        
    }

    private bool Battle()
    {
        bool retVal = false;
        // Prevent eternal cycle 
        int breaker = 999; // The battle cannot leave 999 iterations
        while (breaker > 0)
        {
            if (playerStats.Health != 0)
            {
                PlayerAttack();
            }
            else
            {
                retVal = false;
                break;
            }
            if (enemy.Health != 0)
            {
                EnemyAttack();
            }
            else
            {
                retVal = true;
                break;
            }
            breaker--;
        }
        return retVal;
    }
    private IEnemy GenerateNewEnemy(ZoneData zone)
    {
        IEnemyCreator creator = new RegularEnemyCreator();
        return creator.CreateEnemy(zone.Level);    
    }

    private RewardData GenerateReward()
    {
        RewardData retVal = new RewardData();
        return null;
    }
}
