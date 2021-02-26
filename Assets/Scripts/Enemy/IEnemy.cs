using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    double EnemyHealth { get; set; }
    double EnemyAttack { get; }
    double EnemyDefence { get; }
}
