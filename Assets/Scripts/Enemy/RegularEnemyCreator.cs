using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyCreator : IEnemyCreator
{
    public IEnemy CloneEnemy(IEnemy enemy)
    {
        return new RegularEnemy(enemy);
    }

    public IEnemy CreateEnemy(int zoneLvl)
    {
        return new RegularEnemy(zoneLvl);
    }

    
}
