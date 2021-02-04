using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyCreator
{
    IEnemy CreateEnemy(int zoneLvl);
    IEnemy CloneEnemy(IEnemy enemy);
   }
