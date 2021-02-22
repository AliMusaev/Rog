using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud 
{
    public static HudController Controller;
    public static HudView View;

    private ExpData expData;
    private StepsData playerSteps;
    private ZoneData zoneData;
    public Hud()
    {

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
}
