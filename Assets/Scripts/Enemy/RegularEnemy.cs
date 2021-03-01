using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemy : EnemyBaseParams, IEnemy
{
    private double enemyHealth;
    public double Health
    {
        get => enemyHealth;
        set
        {
            if (enemyHealth < value)
                enemyHealth = 0;
            else
                enemyHealth -= value;
        }
    }
    public double Attack { get; private set; }
    public double Defence { get; private set; }
    public RegularEnemy(int zoneLvl)
    {
        enemyHealth = BaseEnemyHealth * Math.Pow(1.01, zoneLvl);
        Attack = BaseEnemyAttack * Math.Pow(1.01, zoneLvl);
        Defence = BaseEnemyDefence * Math.Pow(1.01, zoneLvl);
    }
    public RegularEnemy(IEnemy enemy)
    {
        this.enemyHealth = enemy.Health;
        this.Attack = enemy.Attack;
        this.Defence = enemy.Defence;
    }

}
