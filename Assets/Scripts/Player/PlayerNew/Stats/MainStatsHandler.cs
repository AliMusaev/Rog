﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStatsHandler
{
    private IMainStats dataController;
    public MainStatsHandler(IMainStats mainStatsController)
    {
        this.dataController = mainStatsController;
    }
    public void ReqUpdateMainStats(MainStatsData newStatsFromUI)
    {
        if (CheckInputStatsValiability(newStatsFromUI))
        {
            
            dataController.RewriteMainStatsData(newStatsFromUI);
        }
        else
        {
            Debug.LogWarning("Values has not assign in MainStatsHandler");
        }
    }
    public MainStatsData GetData()
    {
        return dataController.GetMainStatsData();
    }
    private bool CheckInputStatsValiability(MainStatsData inputStats)
    {
        bool result = false;
        int input = inputStats.Health + inputStats.Attack + inputStats.Defence;
        var a = dataController.GetMainStatsData();
        int act = a.Health + a.Attack + a.Defence;
        if ((input - act) + inputStats.Points == a.Points)
        {
            result = true;
        }
        else
            result = false;
        return result;
        
    }

}
