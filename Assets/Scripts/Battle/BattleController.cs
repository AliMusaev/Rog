using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController
{
    public static event Action<int> GettingNewExp;

    private static System.Random rand;

    private RewardData reward;
    private StatsData playerStats;
    private IEnemy enemy;
    private ZoneData zoneData;
    public BattleController()
    {
        rand = new System.Random();
    }
    public void StartBattle(ZoneData zoneData, StatsData playerStats)
    {

    }


    private void PlayerAttack()
    {
        if (rand.Next(0,10000) < playerStats.CritChance)
        {
        }
    }


}
