using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public static event Action<float> UpdateTraveledDistance;
    public PlayerMovement obj;
    public static float DistanceToTrigger = 100;
    private Rigidbody playersBody;
    private float oldX;
    private float oldZ;
    private static float distanceTraveled;
    public static bool IsReady;
    private System.Random rand;
    public static float DistanceTraveled { get => distanceTraveled;}

    // Start is called before the first frame update
    void Start()
    {
        playersBody = obj.GetComponent<Rigidbody>();
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
            distanceTraveled += Math.Abs(playersBody.worldCenterOfMass.x - oldX) + Math.Abs(playersBody.worldCenterOfMass.z - oldZ);
            if (UpdateTraveledDistance != null)
            {
                UpdateTraveledDistance.Invoke(distanceTraveled);
            }
            
            oldX = playersBody.worldCenterOfMass.x;
            oldZ = playersBody.worldCenterOfMass.z;
            var dist = Math.Round(distanceTraveled);
            if (dist > 60)
            {
                var temp = rand.NextDouble() * DistanceToTrigger * 50;
                if ((temp) < dist || dist >= DistanceToTrigger)
                {
                    distanceTraveled = 0;
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
