using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController
{
    private IGauge dataController;
    private static System.Random rand;
    
    public GaugeController(IGauge dataController)
    {
        rand = new System.Random();
        this.dataController = dataController;

    }

    public void Update(float newXpos, float newZpos)
    {
        var lastValues = dataController.GetLastPosition();
        if (newXpos != lastValues.Xpos && newZpos != lastValues.Zpos)
        {
            lastValues.CurrentDist += Math.Abs(newXpos - lastValues.Xpos) + Math.Abs(newZpos - lastValues.Zpos);
            lastValues.Xpos = newXpos;
            lastValues.Zpos = newZpos;

            dataController.RewritePosition(lastValues);
        }
    }
    public GaugeData GetGaugeValue()
    {
        return dataController.GetLastPosition();
    }
    public bool CheckStatus()
    {
        bool result = false;
        var actualValues = dataController.GetLastPosition();
        if (actualValues.CurrentDist > 60 && actualValues.CurrentDist < 100)
        {
            var temp = rand.NextDouble() * actualValues.maxDist * 50;
            if ((temp) < actualValues.CurrentDist || actualValues.CurrentDist >= actualValues.maxDist)
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        else if (actualValues.CurrentDist >= 100)
        {
            result = true;
        }
        else
        {
            result = false;
        }

        if (result)
        {
            actualValues.CurrentDist = 0;
            dataController.RewritePosition(actualValues);
        }
        return result;

    }
}
