using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGauge : MonoBehaviour
{
    public static event Action<float, float> SendingNewPosition;
    [SerializeField] private Rigidbody PlayersBody;
    void Update()
    {
        if (SendingNewPosition != null)
        {
            if (PlayersBody.velocity != null)
            {
                SendingNewPosition.Invoke(PlayersBody.worldCenterOfMass.x, PlayersBody.worldCenterOfMass.z);
            }
           
        }
    }
}
