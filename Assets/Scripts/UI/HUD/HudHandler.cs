using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudHandler 
{
    public static HudController Controller;
    public static HudView View;

    private ExpData expData;
    private StepsData playerSteps;
    private ZoneData zoneData;
    private GaugeData gaugeData;
    public HudHandler()
    {
        Player.UpdatingExpData += UpdateExpData;
        Player.UpdatingZoneData += UpdateZoneData;
    }
    public void UpdateExpData(ExpData input)
    {
        expData = input;
        View.RepresentExpData(input);
    }
    public void UpdateZoneData(ZoneData input)
    {
        zoneData = input;
        View.RepresentZoneData(input);
    }
    public void UpdateGaugeValue(GaugeData input)
    {
        this.gaugeData = input;
        View.RepresentGaugeData(input);
    }
}
