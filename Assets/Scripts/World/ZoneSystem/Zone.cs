using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    private ZoneDataHandler zoneDataHandler;
    public int ZoneLvl { get => zoneLvl; }
    [SerializeField] int zoneLvl;
    public int ValueType { get => valueType; }
    [SerializeField] int valueType;
    public int Value { get => value; }
    [SerializeField] int value;
    public int StepCounter { get => stepCounter; }
    [SerializeField] int stepCounter;
    private void Start()
    {
        zoneDataHandler = new ZoneDataHandler();
        UpdateZoneValues(zoneDataHandler.GetNewZone());
        PlayerMainController.PlayerMoves += CounterCheck;
    }
    private void CounterCheck()
    {
        stepCounter--;
        if (StepCounter <= 0)
        {
            UpdateZoneValues(zoneDataHandler.GetNewZone());
        }
    }
    private void UpdateZoneValues(int [] newValues)
    {
        this.valueType = newValues[0];
        this.value = newValues[1];
        this.stepCounter = newValues[2];
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMainController.ActualZone = this;
        HUDDataHandler.UpdataZoneInf(this);
    }
}
