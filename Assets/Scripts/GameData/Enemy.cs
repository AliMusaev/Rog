using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public double[] EnemyParams { get; private set; }
   

    public Enemy(int zoneLvl)
    {
        EnemyParams = new double[3];
        EnemyParams[0] = 100 * Math.Pow(1.01, zoneLvl);
        EnemyParams[1] = 15 * Math.Pow(1.01, zoneLvl);
        EnemyParams[2] = 10 * Math.Pow(1.01, zoneLvl);
    }
}
