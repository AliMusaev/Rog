using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    double Health { get; set; }
    double Attack { get; }
    double Defence { get; }
}
