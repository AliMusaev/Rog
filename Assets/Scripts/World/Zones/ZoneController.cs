using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [Header("Zone Parameters")]
    [SerializeField] private int zoneLevel;
    private bool choosenBox;
    private Zone zone;
    // Start is called before the first frame update
    void Start()
    {
        zone = ZoneDataHandler.GetNewZone();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyTrigger.IsReady && choosenBox)
        {
            BattleController bController =  new BattleController(zoneLevel, zone);          
            EnemyTrigger.IsReady = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        choosenBox = true;
    }
    private void OnTriggerExit(Collider other)
    {
        choosenBox = false;
    }
}
