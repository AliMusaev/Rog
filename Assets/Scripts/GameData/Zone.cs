using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone
{
    public int Id { get; private set; }
    public int Value { get; private set; }
    public int StepCounter { get; private set; }
    public Zone(int id, int value, int steps)
    {
        this.Id = id;
        this.Value = value;
        this.StepCounter = steps;
        PlayerMainController.PlayerMoves += CounterCheck;
    }
    public Zone(Zone newZone)
    {
        this.Id = newZone.Id;
        this.Value = newZone.Value;
        this.StepCounter = newZone.StepCounter;
    }
    private void CounterCheck()
    {
        if (StepCounter == 0)
        {
            UpdateZone( new Zone(ZoneDataHandler.GetNewZone()));
        }
        else
        {
            StepCounter--;
        }
    }
    private void UpdateZone (Zone newZone)
    {
        this.Id = newZone.Id;
        this.Value = newZone.Value;
        this.StepCounter = newZone.StepCounter;
    }
}
