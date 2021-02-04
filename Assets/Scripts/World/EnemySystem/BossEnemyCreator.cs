using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyCreator : IEnemyCreator
{
    public IEnemy CloneEnemy(IEnemy enemy)
    {
        return new BossEnemy(enemy);
    }

    public IEnemy CreateEnemy(int zoneLvl)
    {
        return new BossEnemy(zoneLvl);
    }
}
