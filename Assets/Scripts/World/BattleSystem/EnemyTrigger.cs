using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public static event Action CallBattle;
    public static event Action<float> UpdateTraveledDistance;
    public PlayerMovement Player;
    public static float DistanceToTrigger = 100;
    private Rigidbody playersBody;
    private float oldX;
    private float oldZ;
    public static float DistanceTraveled { get; private set; }
    public static bool IsReady;
    private System.Random rand;
    

    // Start is called before the first frame update
    void Start()
    {
        playersBody = Player.GetComponent<Rigidbody>();
        oldX = playersBody.worldCenterOfMass.x;
        oldZ = playersBody.worldCenterOfMass.z;
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoved())
            IsReady = true;     
    }
 
    bool PlayerMoved()
    {
        if (playersBody.worldCenterOfMass.x != oldX && playersBody.worldCenterOfMass.z != oldZ)
        {
            DistanceTraveled += Math.Abs(playersBody.worldCenterOfMass.x - oldX) + Math.Abs(playersBody.worldCenterOfMass.z - oldZ);
            if (UpdateTraveledDistance != null)
            {
                UpdateTraveledDistance.Invoke(DistanceTraveled);
            }
            
            oldX = playersBody.worldCenterOfMass.x;
            oldZ = playersBody.worldCenterOfMass.z;
            var dist = Math.Round(DistanceTraveled);
            if (dist > 60)
            {
                var temp = rand.NextDouble() * DistanceToTrigger * 50;
                if ((temp) < dist || dist >= DistanceToTrigger)
                {
                    DistanceTraveled = 0;
                    CallBattle.Invoke();
                    return true;
                }
                else
                    return false;
            }
            else 
                return false;
        }
        else
            return false;
    }
}
