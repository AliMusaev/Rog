using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : EnemyBaseParams, IEnemy
{
    private double enemyHealth;
    public double Health
    {
        get => enemyHealth;
        set
        {
            if (Health < value)
                Health = 0;
            else
                Health -= value;
        }
    }
    public double Attack { get; private set; }
    public double Defence { get; private set; }
    public EliteEnemy(int zoneLvl)
    {
        enemyHealth = BaseEnemyHealth * Math.Pow(1.11, zoneLvl);
        Attack = BaseEnemyAttack * Math.Pow(1.11, zoneLvl);
        Defence = BaseEnemyDefence * Math.Pow(1.11, zoneLvl);
    }
    public EliteEnemy(IEnemy enemy)
    {
        this.enemyHealth = enemy.Health;
        this.Attack = enemy.Attack;
        this.Defence = enemy.Defence;
    }
}
