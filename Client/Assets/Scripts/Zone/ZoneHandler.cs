using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHandler
{
    IZoneData dataController;
    public ZoneHandler(IZoneData dataController)
    {
        this.dataController = dataController;
        
    }
    public void RewriteZoneData(ZoneData input)
    {
        dataController.RewriteZoneData(input);
    }
    public ZoneData GetData()
    {
        return dataController.GetZoneData();
    }
}
