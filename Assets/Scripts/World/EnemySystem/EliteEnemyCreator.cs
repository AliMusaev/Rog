using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyCreator : IEnemyCreator
{
    public IEnemy CloneEnemy(IEnemy enemy)
    {
        return new EliteEnemy(enemy);
    }

    public IEnemy CreateEnemy(int zoneLvl)
    {
        return new EliteEnemy(zoneLvl);
    }
}
