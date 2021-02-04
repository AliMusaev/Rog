using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemy : EnemyBaseParams, IEnemy
{
    private double enemyHealth;
    public double EnemyHealth
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
    public double EnemyAttack { get; private set; }
    public double EnemyDefence { get; private set; }
    public RegularEnemy(int zoneLvl)
    {
        enemyHealth = BaseEnemyHealth * Math.Pow(1.01, zoneLvl);
        EnemyAttack = BaseEnemyAttack * Math.Pow(1.01, zoneLvl);
        EnemyDefence = BaseEnemyDefence * Math.Pow(1.01, zoneLvl);
    }
    public RegularEnemy(IEnemy enemy)
    {
        this.enemyHealth = enemy.EnemyHealth;
        this.EnemyAttack = enemy.EnemyAttack;
        this.EnemyDefence = enemy.EnemyDefence;
    }

}
