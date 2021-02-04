using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyBaseParams, IEnemy
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
    public BossEnemy(int zoneLvl)
    {
        enemyHealth = BaseEnemyHealth * Math.Pow(2, zoneLvl);
        EnemyAttack = BaseEnemyAttack * Math.Pow(2, zoneLvl);
        EnemyDefence = BaseEnemyDefence * Math.Pow(2, zoneLvl);
    }
    public BossEnemy(IEnemy enemy)
    {
        this.enemyHealth = enemy.EnemyHealth;
        this.EnemyAttack = enemy.EnemyAttack;
        this.EnemyDefence = enemy.EnemyDefence;
    }
}
