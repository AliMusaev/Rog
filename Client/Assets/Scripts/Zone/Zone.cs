using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private int zoneLvl;

    public static event Action<ZoneData> SendingZoneData;

    private ZoneDataCalculator zoneDataHandler;
    private ZoneData zoneData;

    private bool currentZone = false;
    private void Start()
    {
        zoneDataHandler = new ZoneDataCalculator(zoneLvl);

        zoneData = zoneDataHandler.GetNewZone();

        Player.UpdatingStepsData += CounterCheck;
    }
    private void CounterCheck(StepsData useless)
    {
        zoneData.SetpsLeft--;
        if (zoneData.SetpsLeft <= 0)
        {
            zoneData = zoneDataHandler.GetNewZone();
        }
        if (currentZone)
        {
                SendingZoneData.Invoke(zoneData);   
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        currentZone = true;
        SendingZoneData.Invoke(zoneData);
    }
    private void OnTriggerExit(Collider other)
    {
        currentZone = false;
    }
}
