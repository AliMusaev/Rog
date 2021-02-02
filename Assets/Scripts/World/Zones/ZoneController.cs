using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [Header("Zone Parameters")]
    [SerializeField] private int zoneLevel;
    public Zone zone;
    private readonly object obj = new object();
    private bool choosenBox;
    public int a;
    public int b;

    void Start()
    {
        zone = new Zone(zoneLevel);
        a = zone.StepCounter;
        b = zone.ValueType;

    }
    void Update()
    {
        if (EnemyTrigger.IsReady && choosenBox)
        {
            
            a = zone.StepCounter;
            b = zone.ValueType;
            BattleController bController =  new BattleController(zoneLevel, zone);  
            EnemyTrigger.IsReady = false;
            HUDDataHandler.UpdataZoneInf(zone);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        choosenBox = true;
        HUDDataHandler.UpdataZoneInf( zone);
    }
    private void OnTriggerExit(Collider other)
    {
        choosenBox = false;
    }
}
