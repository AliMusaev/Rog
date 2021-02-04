using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemy : EnemyBaseParams, IEnemy
{
    private double enemyHealth;
    public double EnemyHealth
    {
        get => enemyHealth;
        set
        {
            if (EnemyHealth < value)
                EnemyHealth = 0;
            else
                EnemyHealth -= value;
        }
    }
    public double EnemyAttack { get; private set; }
    public double EnemyDefence { get; private set; }
    public EliteEnemy(int zoneLvl)
    {
        enemyHealth = BaseEnemyHealth * Math.Pow(1.11, zoneLvl);
        EnemyAttack = BaseEnemyAttack * Math.Pow(1.11, zoneLvl);
        EnemyDefence = BaseEnemyDefence * Math.Pow(1.11, zoneLvl);
    }
    public EliteEnemy(IEnemy enemy)
    {
        this.enemyHealth = enemy.EnemyHealth;
        this.EnemyAttack = enemy.EnemyAttack;
        this.EnemyDefence = enemy.EnemyDefence;
    }
}
